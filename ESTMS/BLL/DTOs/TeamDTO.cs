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
    public class TeamDTO
    {
        public int TeamId { get; set; }
        [Required]
        [StringLength(50)]
        public string TeamName { get; set; }

        [StringLength(100)]
        public string Website { get; set; }

        [Required]
        [StringLength(100)]
        public string Logo { get; set; }
        [Required]
        public int CaptainId { get; set; }
       
    }
}
