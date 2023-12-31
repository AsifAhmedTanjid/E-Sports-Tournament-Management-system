using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIAppLayer.Controllers
{
    public class SponsorController : ApiController
    {

        [HttpGet]
        [Route("api/sponsors")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = SponsorService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/sponsors/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = SponsorService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [Route("api/sponsors/add")]
        [HttpPost]
        public HttpResponseMessage Add(SponsorDTO s)
        {
            try
            {
                var data = SponsorService.Add(s);
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

        [Route("api/sponsors/update")]
        [HttpPost]
        public HttpResponseMessage Update(SponsorDTO s)
        {
            try
            {
                var data = SponsorService.Update(s);
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
        [Route("api/sponsors/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var res = SponsorService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }
    }
}
