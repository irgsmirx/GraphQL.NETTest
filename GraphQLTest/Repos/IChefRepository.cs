using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLTest.Repos
{
    interface IChefRepository
    {
        IEnumerable<Chef> GetAll();
        Chef GetById(string id);
    }
}
