using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Types;
using GraphQLTest.Repos;
using GraphQLTest.Types;

namespace GraphQLTest
{
    class Query : ObjectGraphType
    {
        public Query(IChefRepository repository)
        {
            Field<ListGraphType<ChefType>>(
                   "chefs",
                   resolve: context => repository.GetAll()
                );

            Field<ChefType>(
                "chef",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return repository.GetById(id);

                }
            );
        }
    }
}
