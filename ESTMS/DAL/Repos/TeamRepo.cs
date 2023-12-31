using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TeamRepo : Repo, IRepo<Team, int, Team>
    {
        public Team Add(Team obj)
        {
            db.Teams.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Teams.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Team> Get()
        {
            return db.Teams.ToList();
        }

        public Team Get(int id)
        {
            return db.Teams.Find(id);
        }

        public Team Update(Team obj)
        {
            var ex = Get(obj.TeamId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }
    }
}
