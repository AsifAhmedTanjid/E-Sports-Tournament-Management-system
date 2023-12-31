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
    public class TeamController : ApiController
    {
        [HttpGet]
        [Route("api/teams")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = TeamService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/teams/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = TeamService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [Route("api/teams/add")]
        [HttpPost]
        public HttpResponseMessage Add(TeamDTO t)
        {
            try
            {
                var data = TeamService.Add(t);
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

        [Route("api/teams/update")]
        [HttpPost]
        public HttpResponseMessage Update(TeamDTO t)
        {
            try
            {
                var data = TeamService.Update(t);
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
        [Route("api/teams/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var res = TeamService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }
    }
}
