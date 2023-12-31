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
    public class GameController : ApiController
    {
        [HttpGet]
        [Route("api/games")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = GameService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/games/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = GameService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [Route("api/games/add")]
        [HttpPost]
        public HttpResponseMessage Add(GameDTO g)
        {
            try
            {
                var data = GameService.Add(g);
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

        [Route("api/games/update")]
        [HttpPost]
        public HttpResponseMessage Update(GameDTO g)
        {
            try
            {
                var data = GameService.Update(g);
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
        [Route("api/games/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var res = GameService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }
    }
}
