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
    public class MatchController : ApiController
    {


        [HttpGet]
        [Route("api/matches")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = MatchService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/matches/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = MatchService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [Route("api/matches/add")]
        [HttpPost]
        public HttpResponseMessage Add(MatchDTO m)
        {
            try
            {
                var data = MatchService.Add(m);
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

        [Route("api/matches/update")]
        [HttpPost]
        public HttpResponseMessage Update(MatchDTO m)
        {
            try
            {
                var data = MatchService.Update(m);
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
        [Route("api/matches/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var res = MatchService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }
    }
}
