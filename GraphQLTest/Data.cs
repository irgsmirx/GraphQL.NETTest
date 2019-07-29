using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLTest
{
    class Data
    {
        public List<Chef> _chefs { get; set; }
        public List<Person> _persons { get; set; }

        public Data()
        {
            _persons = new List<Person>
            {
                new Person {Id = "1", Name = "Detlef", Alter = "25", ChefId = "5"},
                new Person {Id = "2", Name = "Gunther", Alter = "28", ChefId = "5"},
                new Person {Id = "3", Name = "Bob", Alter = "33"},
                new Person {Id = "6", Name = "Donald", Alter = "88"},
                new Person {Id = "7", Name = "Bernd", Alter = "99"},
            };
            _chefs = new List<Chef>
            {
                new Chef {Id = "4", Name = "Gerald"},
                new Chef {Id = "5", Name = "Roland"}
            };
            _chefs.Find(x => x.Id == "5").Employees.Add(_persons.Find(x => x.Id == "1"));
            _persons.Find(x => x.Id == "1").Chef = _chefs.Find(x => x.Id == "5");
            _chefs.Find(x => x.Id == "5").Employees.Add(_persons.Find(x => x.Id == "2"));
            _persons.Find(x => x.Id == "2").Chef = _chefs.Find(x => x.Id == "5");
        }
    }
}
