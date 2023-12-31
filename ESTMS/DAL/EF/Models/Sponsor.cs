using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Sponsor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(11)]
        public string Contact { get; set; }
        
        [StringLength(100)]
        public string logo { get; set; }
       
        [StringLength(100)]
        public string Website { get; set; }
        
        [StringLength(10)]
        public string SponsershipTier { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
