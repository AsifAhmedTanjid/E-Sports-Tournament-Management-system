using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace BLL.Services
{
    public class MatchService
    {
        public static List<MatchDTO> Get()
        {
            var data = DataAccessFactory.MatchData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Match, MatchDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<MatchDTO>>(data);
            return mapped;
        }
        public static MatchDTO Get(int id)
        {
            var data = DataAccessFactory.MatchData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Match, MatchDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<MatchDTO>(data);
            return mapped;
        }

        public static MatchDTO Add(MatchDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<MatchDTO, Match>();
                c.CreateMap<Match, MatchDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Match>(u);

            var ret = DataAccessFactory.MatchData().Add(data);
            if (ret != null) return mapper.Map<MatchDTO>(ret);
            return null;
        }
        public static MatchDTO Update(MatchDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<MatchDTO, Match>();
                c.CreateMap<Match, MatchDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Match>(u);

            var ret = DataAccessFactory.MatchData().Update(data);
            if (ret != null) return mapper.Map<MatchDTO>(ret);
            return null;
        }
        public static bool Delete(int id)
        {
            var res = DataAccessFactory.MatchData().Delete(id);
            return res;
        }


        public static MatchStatDTO Stat(int id)
        {
            var data = DataAccessFactory.MatchStatData().Stat(id);
            var cfg = new MapperConfiguration(c => {
               
                c.CreateMap<Match, MatchDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<MatchDTO>>(data);
            int MatchPlayed = 0;
            int MatchWinner = 0;
            int MatchLoser = 0;
            foreach (var item in mapped)
            {
                if (item.WinnerTeamId == id) MatchWinner++;
                else MatchLoser++;
                MatchPlayed++;
            }

        
            float rate = ((float)MatchWinner / MatchPlayed) * 100;
            string winrate = rate.ToString("0.00") + "%";
            var stats = new MatchStatDTO
            {
                MatchPlayed = MatchPlayed,
                MatchWin = MatchWinner,
                MatchLose = MatchLoser,
                WinRate = winrate
            };
            return stats;
        }
    }
}
