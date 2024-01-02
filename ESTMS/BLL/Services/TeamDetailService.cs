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
    public class TeamDetailService
    {
        public static List<TeamDetailDTO> Get()
        {
            var data = DataAccessFactory.TeamDetailData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TeamDetail, TeamDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<TeamDetailDTO>>(data);
            return mapped;
        }
        public static TeamDetailDTO Get(int id)
        {
            var data = DataAccessFactory.TeamDetailData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TeamDetail, TeamDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<TeamDetailDTO>(data);
            return mapped;
        }

        public static TeamDetailDTO Add(TeamDetailDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TeamDetailDTO, TeamDetail>();
                c.CreateMap<TeamDetail, TeamDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<TeamDetail>(u);

            var ret = DataAccessFactory.TeamDetailData().Add(data);
            if (ret != null) return mapper.Map<TeamDetailDTO>(ret);
            return null;
        }
        public static TeamDetailDTO Update(TeamDetailDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TeamDetailDTO, TeamDetail>();
                c.CreateMap<TeamDetail, TeamDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<TeamDetail>(u);

            var ret = DataAccessFactory.TeamDetailData().Update(data);
            if (ret != null) return mapper.Map<TeamDetailDTO>(ret);
            return null;
        }
        public static bool Delete(int id)
        {
            var res = DataAccessFactory.TeamDetailData().Delete(id);
            return res;
        }
    }
}
