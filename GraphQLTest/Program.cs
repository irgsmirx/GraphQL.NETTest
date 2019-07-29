using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Http;
using GraphQLTest.Repos;
using GraphQLTest.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IDataLoaderContextAccessor, DataLoaderContextAccessor>()
                                                .AddScoped<DataLoaderDocumentListener>()
                                                .AddScoped<IChefRepository, ChefRepository>()
                                                .AddScoped<IPersonRepository, PersonRepository>()
                                                .AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService))
                                                .AddScoped<TestSchema>()
                                                .AddScoped<Query>()
                                                .AddScoped<Data>()
                                                .AddScoped<ChefType>()
                                                .AddScoped<PersonType>();
            var serviceProvider = services.BuildServiceProvider();
            var listener = serviceProvider.GetRequiredService<DataLoaderDocumentListener>();
            var executer = new DocumentExecuter();
            var schema = serviceProvider.GetRequiredService<TestSchema>();

            var result = executer.ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.ExposeExceptions = true;
                _.Query = "{ chefs { id name employees { id name } } }";
                _.Listeners.Add(listener);
            });

            var json = new DocumentWriter(indent: true).Write(result.Result);
            Console.WriteLine(json);
            Console.Read();
        }
    }
}
