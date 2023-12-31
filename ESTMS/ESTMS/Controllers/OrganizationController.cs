using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ESTMS.Controllers
{
    public class OrganizationController : ApiController
    {
        [HttpGet]
        [Route("api/organizations")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = OrganizationService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/organizations/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = OrganizationService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [Route("api/organizations/add")]
        [HttpPost]
        public HttpResponseMessage Add(OrganizationDTO o)
        {
            try
            {
                var data = OrganizationService.Add(o);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid Data" });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/organizations/update")]
        [HttpPost]
        public HttpResponseMessage Update(OrganizationDTO o)
        {
            try
            {
                var data = OrganizationService.Update(o);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid Data" });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/organizations/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var res = OrganizationService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }
    }
}
