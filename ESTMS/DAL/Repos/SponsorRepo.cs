using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SponsorRepo : Repo, IRepo<Sponsor, int, Sponsor>
    {
        public Sponsor Add(Sponsor obj)
        {
            db.Sponsors.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Sponsors.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Sponsor> Get()
        {
            return db.Sponsors.ToList();
        }

        public Sponsor Get(int id)
        {
            return db.Sponsors.Find(id);
        }

        public Sponsor Update(Sponsor obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }
    }
}
