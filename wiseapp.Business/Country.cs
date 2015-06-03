using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wiseapp.Business
{
    public class Country : Entity<int>
    {
        [Required]
        [MaxLength(100)]
        [Display(Name="Country Name")]
        public String Name { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}
