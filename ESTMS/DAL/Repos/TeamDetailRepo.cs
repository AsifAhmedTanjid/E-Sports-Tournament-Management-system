using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TeamDetailRepo : Repo, IRepo<TeamDetail, int, TeamDetail>
    {
        public TeamDetail Add(TeamDetail obj)
        {
            db.TeamDetails.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.TeamDetails.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<TeamDetail> Get()
        {
            return db.TeamDetails.ToList();
        }

        public TeamDetail Get(int id)
        {
            return db.TeamDetails.Find(id);
        }

        public TeamDetail Update(TeamDetail obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }
    }
}
