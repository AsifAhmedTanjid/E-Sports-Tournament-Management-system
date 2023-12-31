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
    public class TournamentDTO
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


        [Required]
        public int OrganizedBy { get; set; }

        [Required]

        public int GameId { get; set; }
        public int PrizePool { get; set; }
        public int RegistrationFee { get; set; }


    }
}
