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
    public class OrganizerController : ApiController
    {
        [HttpGet]
        [Route("api/organizers")]
        public HttpResponseMessage Organizers()
        {
            try
            {
                var data = OrganizerService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/organizer/{id}")]
        public HttpResponseMessage Organizers(int id)
        {
            try
            {
                var data = OrganizerService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [Route("api/organizers/add")]
        [HttpPost]
        public HttpResponseMessage Add(OrganizerDTO o)
        {
            try
            {
                var data = OrganizerService.Add(o);
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

        [Route("api/organizers/update")]
        [HttpPost]
        public HttpResponseMessage Update(OrganizerDTO o)
        {
            try
            {
                var data = OrganizerService.Update(o);
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
        [Route("api/organizers/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var res = OrganizerService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }
    }
}
