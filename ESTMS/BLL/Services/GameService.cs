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
    public class GameService
    {
        public static List<GameDTO> Get()
        {
            var data = DataAccessFactory.GameData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Game, GameDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<GameDTO>>(data);
            return mapped;
        }
        public static GameDTO Get(int id)
        {
            var data = DataAccessFactory.GameData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Game, GameDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<GameDTO>(data);
            return mapped;
        }

        public static GameDTO Add(GameDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<GameDTO, Game>();
                c.CreateMap<Game, GameDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Game>(u);

            var ret = DataAccessFactory.GameData().Add(data);
            if (ret != null) return mapper.Map<GameDTO>(ret);
            return null;
        }
        public static GameDTO Update(GameDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<GameDTO, Game>();
                c.CreateMap<Game, GameDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Game>(u);

            var ret = DataAccessFactory.GameData().Update(data);
            if (ret != null) return mapper.Map<GameDTO>(ret);
            return null;
        }
        public static bool Delete(int id)
        {
            var res = DataAccessFactory.GameData().Delete(id);
            return res;
        }
    }
}
