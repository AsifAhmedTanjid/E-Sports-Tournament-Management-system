using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, User> , IAuth<bool>
    {
        public User Add(User obj)
        {
            db.Users.Add(obj);
            if(db.SaveChanges()>0) return obj;
            else return null;
        }

        public bool Authenticate(string username, string password)
        {
           var data = (from u in db.Users
                      where u.Username.Equals(username) && u.Password.Equals(password)  
                      select u).SingleOrDefault();
            if(data!=null) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Users.Remove(ex);   
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
           return db.Users.Find(id);
        }

        public User Update(User obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }
    }
}
