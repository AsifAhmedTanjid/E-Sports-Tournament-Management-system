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
    public class OrganizerService
    {
        public static List<OrganizerDTO> Get()
        {
            var data = DataAccessFactory.OrganizerData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Organizer, OrganizerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<OrganizerDTO>>(data);
            return mapped;
        }
        public static OrganizerDTO Get(int id)
        {
            var data = DataAccessFactory.OrganizerData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Organizer, OrganizerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrganizerDTO>(data);
            return mapped;
        }

        public static OrganizerDTO Add(OrganizerDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrganizerDTO, Organizer>();
                c.CreateMap<Organizer, OrganizerDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Organizer>(u);

            var ret = DataAccessFactory.OrganizerData().Add(data);
            if (ret != null) return mapper.Map<OrganizerDTO>(ret);
            return null;
        }
        public static OrganizerDTO Update(OrganizerDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrganizerDTO, Organizer>();
                c.CreateMap<Organizer, OrganizerDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Organizer>(u);

            var ret = DataAccessFactory.OrganizerData().Update(data);
            if (ret != null) return mapper.Map<OrganizerDTO>(ret);
            return null;
        }
        public static bool Delete(int id)
        {
            var res = DataAccessFactory.OrganizerData().Delete(id);
            return res;
        }
    }
}
