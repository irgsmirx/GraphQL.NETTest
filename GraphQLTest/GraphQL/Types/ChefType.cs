using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLTest.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLTest.Types
{
    class ChefType : ObjectGraphType<Chef>
    {
        public ChefType(IPersonRepository repository, IDataLoaderContextAccessor dataLoader)
        {
            Field<NonNullGraphType<IdGraphType>>("id");
            Field<StringGraphType>("name");
            Field<ListGraphType<PersonType>>(
                "employees",
                resolve: context =>
                {
                    var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<String, Person>("GetPersonsByChefIds", repository.GetPersonsByChefIds);
                    return loader.LoadAsync(context.Source.Id);
                });

        }
    }
}
