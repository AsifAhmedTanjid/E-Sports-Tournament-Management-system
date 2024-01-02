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
    public class TeamDetailDTO
    {
        public int Id { get; set; }
        
        public int? TeamId { get; set; }
       
        public int? PlayerId { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; }
    }
}
