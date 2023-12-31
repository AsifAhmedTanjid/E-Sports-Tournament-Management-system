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
    public class SponsorService
    {
        public static List<SponsorDTO> Get()
        {
            var data = DataAccessFactory.SponsorData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Sponsor, SponsorDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<SponsorDTO>>(data);
            return mapped;
        }
        public static SponsorDTO Get(int id)
        {
            var data = DataAccessFactory.SponsorData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Sponsor, SponsorDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SponsorDTO>(data);
            return mapped;
        }

        public static SponsorDTO Add(SponsorDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SponsorDTO, Sponsor>();
                c.CreateMap<Sponsor, SponsorDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Sponsor>(u);

            var ret = DataAccessFactory.SponsorData().Add(data);
            if (ret != null) return mapper.Map<SponsorDTO>(ret);
            return null;
        }
        public static SponsorDTO Update(SponsorDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SponsorDTO, Sponsor>();
                c.CreateMap<Sponsor, SponsorDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Sponsor>(u);

            var ret = DataAccessFactory.SponsorData().Update(data);
            if (ret != null) return mapper.Map<SponsorDTO>(ret);
            return null;
        }
        public static bool Delete(int id)
        {
            var res = DataAccessFactory.SponsorData().Delete(id);
            return res;
        }
    }
}
