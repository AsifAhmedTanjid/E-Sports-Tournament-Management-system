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
    public class TournamentTeamDetailController : ApiController
    {
            [HttpGet]
            [Route("api/tournamentteamdetails")]
            public HttpResponseMessage GetAll()
            {
                try
                {
                    var data = TournamentTeamDetailService.Get();
                    return Request.CreateResponse(HttpStatusCode.OK, data);

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
                }
            }
            [HttpGet]
            [Route("api/tournamentteamdetails/{id}")]
            public HttpResponseMessage Get(int id)
            {
                try
                {
                    var data = TournamentTeamDetailService.Get(id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
                }
            }
            [Route("api/tournamentteamdetails/add")]
            [HttpPost]
            public HttpResponseMessage Add(TournamentTeamDetailDTO t)
            {
                try
                {
                    var data = TournamentTeamDetailService.Add(t);
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

            [Route("api/tournamentteamdetails/update")]
            [HttpPost]
            public HttpResponseMessage Update(TournamentTeamDetailDTO t)
            {
                try
                {
                    var data = TournamentTeamDetailService.Update(t);
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
            [Route("api/tournamentteamdetails/delete/{id}")]
            public HttpResponseMessage Delete(int id)
            {
                var res = TournamentTeamDetailService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, res);

            }
        
    }
}
