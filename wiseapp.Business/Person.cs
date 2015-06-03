using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wiseapp.Business
{
    public class Person : AuditableEntity<long>
    {
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }

        [Required]
        [MaxLength(50)]
        public String Phone { get; set; }

        [Required]
        [MaxLength(50)]
        public String Address { get; set; }

        [Required]
        [MaxLength(50)]
        public String State { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}
