using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class GameDTO
    {
        public int GameId { get; set; }
        [Required]
        [StringLength(50)]
        public string GameName { get; set; }

        [StringLength(100)]
        public string GameWebsite { get; set; }

        [Required]
        [StringLength(100)]
        public string GameLogo { get; set; }


        [Required]
        [StringLength(50)]
        public string Genre { get; set; }
        [Required]
        [StringLength(50)]
        public string Platform { get; set; }
        [Required]

        public string GameRules { get; set; }
    }
}
