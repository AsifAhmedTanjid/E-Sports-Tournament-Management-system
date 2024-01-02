using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITournament<CLASS>
    {
        List<CLASS> Ongoing();
        List<CLASS> Upcoming();
        List<CLASS> RegistrationOpen();
    }
}
