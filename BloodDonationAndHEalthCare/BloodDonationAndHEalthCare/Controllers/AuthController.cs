using BLL.Services;
using BloodDonationAndHEalthCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BloodDonationAndHEalthCare.Controllers
{
    [EnableCors("http://localhost:3000", "*", "*", SupportsCredentials = true)]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginModels login)
        {
            try
            {
                var res = AuthService.Authenticate(login.Email, login.Password);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found " });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/logout")]
        public HttpResponseMessage Logout()
        {
            try
            {
                string tokenKey = Request.Headers.GetValues("Authorization").FirstOrDefault();

                if (!string.IsNullOrEmpty(tokenKey))
                {
                    if (AuthService.Logout(tokenKey))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Logout successful" });
                    }
                }

                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Invalid or missing token" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }

}
