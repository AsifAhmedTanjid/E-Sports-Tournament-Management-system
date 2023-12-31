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
    public class UserController : ApiController
    {

        [HttpGet]
        [Route("api/users/login")]
        public HttpResponseMessage Authenticate(UserDTO u)
        {
            try
            {
                var data = AuthService.Authenticate(u.Username,u.Password);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/users")]
        public HttpResponseMessage Users()
        {
            try
            {
                var data = UserService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/users/{id}")]
        public HttpResponseMessage Users(int id)
        {
            try
            {
                var data = UserService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [Route("api/users/add")]
        [HttpPost]
        public HttpResponseMessage Add(UserDTO u)
        {
            try
            {
                var data = UserService.AddUser(u);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message ="Invalid Data" });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/users/update")]
        [HttpPost]
        public HttpResponseMessage Update(UserDTO u)
        {
            try
            {
                var data = UserService.UpdateUser(u);
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
        [Route("api/users/delete/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            var res = UserService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }
    }
}
