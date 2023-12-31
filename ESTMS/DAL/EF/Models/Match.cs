using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Match
    {
        public int Id { get; set; }

        [ForeignKey("Tournament")]
        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }

        [Required]
        public DateTime MatchDate { get; set; }

        [ForeignKey("Team1")]
        public int? Team1Id { get; set; }
        public virtual Team Team1 { get; set; }

        [ForeignKey("Team2")]
        public int? Team2Id { get; set; }
        public virtual Team Team2 { get; set; }

        [ForeignKey("WinnerTeam")]
        public int? WinnerTeamId { get; set; }
        public virtual Team WinnerTeam { get; set; }

        public string Score { get; set; }
    }
}
