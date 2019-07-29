using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLTest
{
    class Chef
    {
        [Key]
        public String Id { get; set; }
        public String Name { get; set; }
        public List<Person> Employees { get; set; }
        public Chef()
        {
            Employees = new List<Person>();
        }
    }
}
