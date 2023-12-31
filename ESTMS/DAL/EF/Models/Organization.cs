using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Organization
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string OrganizationName { get; set; }
        [Required]
        [StringLength(10)]
        public string Country { get; set; }
        [StringLength(100)]
        public string Website { get; set; }
        [StringLength(100)]
        public string Logo { get; set; }
        [StringLength(100)]
        public string Cover { get; set; }
      
        public string Description { get; set; }

        [ForeignKey("Organizer")]
        public int Owner { get; set; }
        public virtual Organizer Organizer { get; set; }

    }
}
