using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MatchStatDTO 
    {
            public int MatchPlayed { get; set; }
            public int MatchWin { get; set; }
            public int MatchLose { get; set; }
            public string WinRate { get; set; }
    }
}
