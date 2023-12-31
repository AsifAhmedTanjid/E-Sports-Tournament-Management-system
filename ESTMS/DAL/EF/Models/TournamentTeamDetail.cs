using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class TournamentTeamDetail
    {
        public int Id { get; set; }
      
        [ForeignKey("Tournament")]
        public int? TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }

        [ForeignKey("Team")]
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
