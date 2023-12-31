using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TournamentRepo : Repo, IRepo<Tournament, int, Tournament>
    {
        public Tournament Add(Tournament obj)
        {
            db.Tournaments.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Tournaments.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Tournament> Get()
        {
            return db.Tournaments.ToList();
        }

        public Tournament Get(int id)
        {
            return db.Tournaments.Find(id);
        }

        public Tournament Update(Tournament obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }
    }
}
