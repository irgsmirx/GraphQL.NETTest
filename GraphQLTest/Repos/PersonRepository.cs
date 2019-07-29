using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLTest.Repos
{
    class PersonRepository : IPersonRepository
    {
        private readonly Data _context;
        public PersonRepository(Data context)
        {
            _context = context;
        }
        public IEnumerable<Person> GetAllPersonsPerChef(String chefId)
        {
            List<Person> temp = _context._persons.FindAll(x => x.ChefId.Equals(chefId));
            return temp;
        }

        public async Task<ILookup<String, Person>> GetPersonsByChefIds(IEnumerable<String> chefIds)
        {
            var temp = await Task<ILookup<String, Person>>.FromResult(_context._persons.Where(a => chefIds.Contains(a.ChefId)).ToLookup(x => x.ChefId));
            return temp;
        }
    }
}
