using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TournamentTeamDetailDTO
    {
        public int Id { get; set; }

        
        public int? TournamentId { get; set; }
   
        public int? TeamId { get; set; }
   
    }
}
