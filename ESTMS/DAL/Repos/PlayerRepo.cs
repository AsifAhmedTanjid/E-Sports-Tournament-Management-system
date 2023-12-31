using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PlayerRepo : Repo, IRepo<Player, int, Player>
    {
        public Player Add(Player obj)
        {
            db.Players.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Players.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Player> Get()
        {
            return db.Players.ToList();
        }

        public Player Get(int id)
        {
            return db.Players.Find(id);
        }

        public Player Update(Player obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }
    }
}
