using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITournamentSearch <CLASS,SEARCH>
    {
        
            List<CLASS> Search(SEARCH search);
         
        
    }
}

