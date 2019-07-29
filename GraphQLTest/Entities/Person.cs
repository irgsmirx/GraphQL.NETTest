using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLTest
{
    class Person
    {
        [Key]
        public String Id { get; set; }
        public String Name { get; set; }
        public String Alter { get; set; }

        [ForeignKey("ChefId")]
        public String ChefId { get; set; }
        public Chef Chef { get; set; }
    }
}
