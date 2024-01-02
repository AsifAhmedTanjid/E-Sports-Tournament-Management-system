using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class TeamDetail
    {
        public int Id { get; set; }

        [ForeignKey("Team")]
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }

        [ForeignKey("Player")]
        public int? PlayerId { get; set; }
        public virtual Player Player { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; }


    }
}
