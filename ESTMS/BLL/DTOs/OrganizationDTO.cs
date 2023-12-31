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
    public class OrganizationDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string OrganizationName { get; set; }
        [Required]
        [StringLength(10)]
        public string Country { get; set; }
        [StringLength(100)]
        public string Website { get; set; }
        [StringLength(100)]
        public string Logo { get; set; }
        [StringLength(100)]
        public string Cover { get; set; }

        public string Description { get; set; }

       
        public int Owner { get; set; }
        
    }
}
