using BLL.DTO;
using BLL.Services;
using BloodDonationAndHEalthCare.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloodDonationAndHEalthCare.Controllers
{
    public class CompleteDonationController : ApiController
    {
        [HttpPost]
        [Logged]

        [Route("api/CompleteDonation/add/Post/{PostId}")]
        public HttpResponseMessage CompleteDonation(int PostId)
        {
            try
            {
                var token = ActionContext.Request.Headers.Authorization;

                var data = CompleteDonationService.AddCompleteDonationService(PostId, token.ToString());
                return Request.CreateResponse(HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpGet]
        [Logged]
        [Route("api/CompleteDonation/remainTime")]
        public HttpResponseMessage RemainTimeForDonation()
        {
            try
            {
                var token = ActionContext.Request.Headers.Authorization;

                var data = CompleteDonationService.RemainTime(token.ToString());
                return Request.CreateResponse(HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
    }
}