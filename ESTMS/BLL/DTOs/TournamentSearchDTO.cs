using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TournamentSearchDTO : TournamentDTO
    {
        public List<TournamentDTO> Tournaments { get; set; }
        public TournamentSearchDTO()
        {
            Tournaments = new List<TournamentDTO>();
        }
    }
}
