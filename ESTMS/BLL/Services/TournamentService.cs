using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services
{
    public class TournamentService
    {
        public static List<TournamentDTO> Get()
        {
            var data = DataAccessFactory.TournamentData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Tournament, TournamentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<TournamentDTO>>(data);
            return mapped;
        }
        public static TournamentDTO Get(int id)
        {
            var data = DataAccessFactory.TournamentData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Tournament, TournamentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<TournamentDTO>(data);
            return mapped;
        }

        public static TournamentDTO Add(TournamentDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TournamentDTO, Tournament>();
                c.CreateMap<Tournament, TournamentDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Tournament>(u);

            var ret = DataAccessFactory.TournamentData().Add(data);
            if (ret != null) return mapper.Map<TournamentDTO>(ret);
            return null;
        }
        public static TournamentDTO Update(TournamentDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TournamentDTO, Tournament>();
                c.CreateMap<Tournament, TournamentDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Tournament>(u);

            var ret = DataAccessFactory.TournamentData().Update(data);
            if (ret != null) return mapper.Map<TournamentDTO>(ret);
            return null;
        }
        public static bool Delete(int id)
        {
            var res = DataAccessFactory.TournamentData().Delete(id);
            return res;
        }

        public static TournamentMatchDTO GetwithMatches(int id)
        {
            var data = DataAccessFactory.TournamentData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Tournament, TournamentMatchDTO>();
                c.CreateMap<Match, MatchDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<TournamentMatchDTO>(data);
            return mapped;

        }

        public static List<TournamentDTO> Search(string search)
        {
            var data = DataAccessFactory.TournamentSearchData().Search(search);
            var cfg = new MapperConfiguration(c => {
               // c.CreateMap<Tournament, TournamentSearchDTO>();
                c.CreateMap<Tournament, TournamentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<TournamentDTO>>(data);
            return mapped;

        }

        public static List<TournamentDTO> Ongoing()
        {

            var data = DataAccessFactory.TournamentFilterData().Ongoing();
            var cfg = new MapperConfiguration(c => {
               
                c.CreateMap<Tournament, TournamentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<TournamentDTO>>(data);
            return mapped;

        }
        public static List<TournamentDTO> Upcoming()
        {

            var data = DataAccessFactory.TournamentFilterData().Upcoming();
            var cfg = new MapperConfiguration(c => {
                // c.CreateMap<Tournament, TournamentSearchDTO>();
                c.CreateMap<Tournament, TournamentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<TournamentDTO>>(data);
            return mapped;

        }
        public static List<TournamentDTO> RegistrationOpen()
        {

            var data = DataAccessFactory.TournamentFilterData().RegistrationOpen();
            var cfg = new MapperConfiguration(c => {
                
                c.CreateMap<Tournament, TournamentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<TournamentDTO>>(data);
            return mapped;

        }


        public static TournamentStatDTO Stat(int id)
        {
            var data = DataAccessFactory.TournamentTeamStatData().Stat(id);
            var cfg = new MapperConfiguration(c => {

                c.CreateMap<Tournament, TournamentDTO>();
                c.CreateMap<TournamentTeamDetail, TournamentTeamDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<TournamentTeamDetailDTO>>(data);
            
            int TotalTeam = 0;

            if (mapped != null) { TotalTeam = mapped.Count(); }

            var data1 = DataAccessFactory.TournamentData().Get(id);
            var cfg1 = new MapperConfiguration(c =>
            {
                c.CreateMap<Tournament, TournamentDTO>();
            });
            var mapper1 = new Mapper(cfg);
            var mapped1 = mapper.Map<TournamentDTO>(data1);

            int prizepool = mapped1.PrizePool;
            int registrationfee = mapped1.RegistrationFee;
            int totalcollectedfee = TotalTeam * registrationfee;

            var stats = new TournamentStatDTO
            {
               RegisteredTeam = TotalTeam,
               PrizePool = prizepool,
               RegistrationFee = registrationfee,
               TotalCollectedFee = totalcollectedfee
               
            };
            return stats;
        }
    }
}
