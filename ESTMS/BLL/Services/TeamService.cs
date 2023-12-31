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
    public class TeamService
    {
        public static List<TeamDTO> Get()
        {
            var data = DataAccessFactory.TeamData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Team, TeamDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<TeamDTO>>(data);
            return mapped;
        }
        public static TeamDTO Get(int id)
        {
            var data = DataAccessFactory.TeamData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Team, TeamDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<TeamDTO>(data);
            return mapped;
        }

        public static TeamDTO Add(TeamDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TeamDTO, Team>();
                c.CreateMap<Team, TeamDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Team>(u);

            var ret = DataAccessFactory.TeamData().Add(data);
            if (ret != null) return mapper.Map<TeamDTO>(ret);
            return null;
        }
        public static TeamDTO Update(TeamDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TeamDTO, Team>();
                c.CreateMap<Team, TeamDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Team>(u);

            var ret = DataAccessFactory.TeamData().Update(data);
            if (ret != null) return mapper.Map<TeamDTO>(ret);
            return null;
        }
        public static bool Delete(int id)
        {
            var res = DataAccessFactory.TeamData().Delete(id);
            return res;
        }
    }
}
