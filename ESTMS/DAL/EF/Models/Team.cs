using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        [Required]
        [StringLength(50)]
        public string TeamName { get; set; }
        
        [StringLength(100)]
        public string Website{ get; set; }
    
        [Required]
        [StringLength(100)]
        public string Logo { get; set; }
        [ForeignKey("Player")]
        public int CaptainId { get; set; }
        public virtual Player Player { get; set; }
    }
}
