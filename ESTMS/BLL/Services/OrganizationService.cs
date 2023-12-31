using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrganizationService
    {
        public static List<OrganizationDTO> Get()
        {
            var data = DataAccessFactory.OrganizationData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Organization, OrganizationDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<OrganizationDTO>>(data);
            return mapped;
        }
        public static OrganizationDTO Get(int id)
        {
            var data = DataAccessFactory.OrganizationData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Organization, OrganizationDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrganizationDTO>(data);
            return mapped;
        }

        public static OrganizationDTO Add(OrganizationDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrganizationDTO, Organization>();
                c.CreateMap<Organization, OrganizationDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Organization>(u);

            var ret = DataAccessFactory.OrganizationData().Add(data);
            if (ret != null) return mapper.Map<OrganizationDTO>(ret);
            return null;
        }
        public static OrganizationDTO Update(OrganizationDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrganizationDTO, Organization>();
                c.CreateMap<Organization, OrganizationDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Organization>(u);

            var ret = DataAccessFactory.OrganizationData().Update(data);
            if (ret != null) return mapper.Map<OrganizationDTO>(ret);
            return null;
        }
        public static bool Delete(int id)
        {
            var res = DataAccessFactory.OrganizationData().Delete(id);
            return res;
        }
    }
}
