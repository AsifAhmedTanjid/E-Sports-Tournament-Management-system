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
    public class PlayerController : ApiController
    {
        [HttpGet]
        [Route("api/players")]
        public HttpResponseMessage Players()
        {
            try
            {
                var data = PlayerService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/players/{id}")]
        public HttpResponseMessage Players(int id)
        {
            try
            {
                var data = PlayerService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [Route("api/players/add")]
        [HttpPost]
        public HttpResponseMessage Add(PlayerDTO p)
        {
            try
            {
                var data = PlayerService.Add(p);
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

        [Route("api/players/update")]
        [HttpPost]
        public HttpResponseMessage Update(PlayerDTO p)
        {
            try
            {
                var data = PlayerService.Update(p);
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
        [Route("api/players/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var res = PlayerService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }
    }
}
