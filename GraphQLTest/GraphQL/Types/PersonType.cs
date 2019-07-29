using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLTest.Types
{
    class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field<IdGraphType>("id");
            Field<StringGraphType>("name");
            Field<StringGraphType>("alter");
            Field<IdGraphType>("chefId");
            Field<ChefType>("chef");
        }
    }
}
