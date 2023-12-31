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
    public class PlayerService
    {
        public static List<PlayerDTO> Get()
        {
            var data = DataAccessFactory.PlayerData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Player, PlayerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PlayerDTO>>(data);
            return mapped;
        }
        public static PlayerDTO Get(int id)
        {
            var data = DataAccessFactory.PlayerData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Player, PlayerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PlayerDTO>(data);
            return mapped;
        }

        public static PlayerDTO Add(PlayerDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PlayerDTO, Player>();
                c.CreateMap<Player, PlayerDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Player>(u);

            var ret = DataAccessFactory.PlayerData().Add(data);
            if (ret != null) return mapper.Map<PlayerDTO>(ret);
            return null;
        }
        public static PlayerDTO Update(PlayerDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PlayerDTO, Player>();
                c.CreateMap<Player, PlayerDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Player>(u);

            var ret = DataAccessFactory.PlayerData().Update(data);
            if (ret != null) return mapper.Map<PlayerDTO>(ret);
            return null;
        }
        public static bool Delete(int id)
        {
            var res = DataAccessFactory.PlayerData().Delete(id);
            return res;
        }
    }
}
