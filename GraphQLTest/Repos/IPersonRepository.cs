using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLTest.Repos
{
    interface IPersonRepository
    {
        IEnumerable<Person> GetAllPersonsPerChef(String chefId);
        Task<ILookup<String, Person>> GetPersonsByChefIds(IEnumerable<String> chefIds);
    }
}
