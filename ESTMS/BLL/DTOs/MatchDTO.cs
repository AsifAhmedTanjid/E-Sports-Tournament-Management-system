using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MatchDTO
    {
        public int Id { get; set; }

        
        public int TournamentId { get; set; }
     

        [Required]
        public DateTime MatchDate { get; set; }

    
        public int? Team1Id { get; set; }
      

        public int? Team2Id { get; set; }
       

      
        public int? WinnerTeamId { get; set; }
        

        public string Score { get; set; }
    }
}
