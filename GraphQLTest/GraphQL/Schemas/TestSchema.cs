using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
namespace GraphQLTest
{
    class TestSchema : Schema
    {
        public TestSchema(IDependencyResolver services, Query query)
            : base(services)
        {
            Query = query;
        }
    }
}
