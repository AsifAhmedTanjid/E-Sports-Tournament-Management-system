using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TournamentTeamDetailRepo : Repo, IRepo<TournamentTeamDetail, int, TournamentTeamDetail>, ITournamentTeamStat<TournamentTeamDetail, int>
    {
        public TournamentTeamDetail Add(TournamentTeamDetail obj)
        {
            db.TournamentTeamDetails.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.TournamentTeamDetails.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<TournamentTeamDetail> Get()
        {
            return db.TournamentTeamDetails.ToList();
        }

        public TournamentTeamDetail Get(int id)
        {
            return db.TournamentTeamDetails.Find(id);
        }

        public List<TournamentTeamDetail> Stat(int id)
        {
            var data = db.TournamentTeamDetails.Where(tt => tt.TournamentId == id).ToList();
            return data;
        }

        public TournamentTeamDetail Update(TournamentTeamDetail obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }
    }
}
