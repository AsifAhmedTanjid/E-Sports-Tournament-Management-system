using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TournamentTeamDetailService
    {
        public static List<TournamentTeamDetailDTO> Get()
        {
            var data = DataAccessFactory.TournamentTeamDetailData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TournamentTeamDetail, TournamentTeamDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<TournamentTeamDetailDTO>>(data);
            return mapped;
        }
        public static TournamentTeamDetailDTO Get(int id)
        {
            var data = DataAccessFactory.TournamentTeamDetailData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TournamentTeamDetail, TournamentTeamDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<TournamentTeamDetailDTO>(data);
            return mapped;
        }

        public static TournamentTeamDetailDTO Add(TournamentTeamDetailDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TournamentTeamDetailDTO, TournamentTeamDetail>();
                c.CreateMap<TournamentTeamDetail, TournamentTeamDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<TournamentTeamDetail>(u);

            var ret = DataAccessFactory.TournamentTeamDetailData().Add(data);
            if (ret != null) return mapper.Map<TournamentTeamDetailDTO>(ret);
            return null;
        }
        public static TournamentTeamDetailDTO Update(TournamentTeamDetailDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TournamentTeamDetailDTO, TournamentTeamDetail>();
                c.CreateMap<TournamentTeamDetail, TournamentTeamDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<TournamentTeamDetail>(u);

            var ret = DataAccessFactory.TournamentTeamDetailData().Update(data);
            if (ret != null) return mapper.Map<TournamentTeamDetailDTO>(ret);
            return null;
        }
        public static bool Delete(int id)
        {
            var res = DataAccessFactory.TournamentTeamDetailData().Delete(id);
            return res;
        }
    }
}
