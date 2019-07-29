using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLTest.Repos
{
    class ChefRepository : IChefRepository
    {
        private readonly Data _context;
        public ChefRepository(Data context)
        {
            _context = context;
        }

        public IEnumerable<Chef> GetAll()
        {
            return _context._chefs;
        }

        public Chef GetById(string id)
        {
            return _context._chefs.Find(x => x.Id == id);
        }
    }
}
