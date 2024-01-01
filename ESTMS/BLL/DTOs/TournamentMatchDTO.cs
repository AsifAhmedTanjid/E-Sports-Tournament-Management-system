using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TournamentMatchDTO : TournamentDTO
    {
    
            public List<MatchDTO> Matches { get; set; }
            public TournamentMatchDTO()
            {
                 Matches = new List<MatchDTO>();
            }
        
    }
}
