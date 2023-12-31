using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OrganizerRepo : Repo, IRepo<Organizer, int, Organizer>
    {
        public Organizer Add(Organizer obj)
        {
            db.Organizers.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Organizers.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Organizer> Get()
        {
            return db.Organizers.ToList();
        }

        public Organizer Get(int id)
        {
            return db.Organizers.Find(id);
        }

        public Organizer Update(Organizer obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }
    }
}
