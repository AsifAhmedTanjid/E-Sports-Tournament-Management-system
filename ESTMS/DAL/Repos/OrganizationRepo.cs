using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OrganizationRepo : Repo, IRepo<Organization, int, Organization>
    {
        public Organization Add(Organization obj)
        {
            db.Organizations.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Organizations.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Organization> Get()
        {
            return db.Organizations.ToList(); ;
        }

        public Organization Get(int id)
        {
            return db.Organizations.Find(id);
        }

        public Organization Update(Organization obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }
    }
}
