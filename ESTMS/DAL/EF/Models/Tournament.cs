using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.EF.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string TournamentTitle { get; set; }
        [Required]
        [StringLength(100)]
        public string TournamentLogo { get; set; }

        [Required]
        public DateTime RegistrationOpenDate { get; set; }

        [Required]
        public DateTime RegistrationCloseDate { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }


        [ForeignKey("Organizer")]
        public int OrganizedBy { get; set; }


        [ForeignKey("Game")]
        public int GameId { get; set; }
        public int PrizePool { get; set; }
        public int RegistrationFee { get; set; }

        public virtual Game Game { get; set; }
        public virtual Organizer Organizer { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
        public Tournament()
        {
            Matches = new List<Match>();
        }

    }
}
