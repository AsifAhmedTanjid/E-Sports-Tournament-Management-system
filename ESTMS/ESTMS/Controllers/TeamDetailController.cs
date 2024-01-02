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
    public class TeamDetailController : ApiController
    {
        [HttpGet]
        [Route("api/teamdetails")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = TeamDetailService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/teamdetails/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = TeamDetailService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [Route("api/teamdetails/add")]
        [HttpPost]
        public HttpResponseMessage Add(TeamDetailDTO t)
        {
            try
            {
                var data = TeamDetailService.Add(t);
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

        [Route("api/teamdetails/update")]
        [HttpPost]
        public HttpResponseMessage Update(TeamDetailDTO t)
        {
            try
            {
                var data = TeamDetailService.Update(t);
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
        [Route("api/teamdetails/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var res = TeamDetailService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }
    }
}
