using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TournamentStatDTO
    {
        public int RegisteredTeam { get; set; }
        public int RegistrationFee { get; set; }
        public int PrizePool { get; set; }
        public int TotalCollectedFee { get; set; }
        
    }
}
