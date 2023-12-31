using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class GameRepo : Repo, IRepo<Game, int, Game>
    {
        public Game Add(Game obj)
        {
            db.Games.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Games.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Game> Get()
        {
            return db.Games.ToList();
        }

        public Game Get(int id)
        {
            return db.Games.Find(id);
        }

        public Game Update(Game obj)
        {
            var ex = Get(obj.GameId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }
    }
}
