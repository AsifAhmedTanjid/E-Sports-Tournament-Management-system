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
    public class TournamentController : ApiController
    {

        [HttpGet]
        [Route("api/tournaments")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = TournamentService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/tournaments/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = TournamentService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [Route("api/tournaments/add")]
        [HttpPost]
        public HttpResponseMessage Add(TournamentDTO t)
        {
            try
            {
                var data = TournamentService.Add(t);
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

        [Route("api/tournaments/update")]
        [HttpPost]
        public HttpResponseMessage Update(TournamentDTO t)
        {
            try
            {
                var data = TournamentService.Update(t);
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
        [Route("api/tournaments/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var res = TournamentService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }
    }
}
