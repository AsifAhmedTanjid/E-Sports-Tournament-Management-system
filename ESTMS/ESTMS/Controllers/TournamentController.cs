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

        [HttpGet]
        [Route("api/tournaments/{id}/matches")]
        public HttpResponseMessage TournamentMatches(int id)
        {
            try
            {
                var data = TournamentService.GetwithMatches(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/tournaments/search/{search}")]
        public HttpResponseMessage Search(string search)
        {
            try
            {
                var data = TournamentService.Search(search);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/tournaments/ongoing")]
        public HttpResponseMessage Ongoing()
        {
            try
            {
                var data = TournamentService.Ongoing();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/tournaments/upcoming")]
        public HttpResponseMessage Upcoming()
        {
            try
            {
                var data = TournamentService.Upcoming();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/tournaments/registrationopen")]
        public HttpResponseMessage RegistrationOpen(){
            try
            {
                var data = TournamentService.RegistrationOpen();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/tournaments/stat/{id}")]
        public HttpResponseMessage Stat(int id)
        {
            try
            {
                var data = TournamentService.Stat(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
