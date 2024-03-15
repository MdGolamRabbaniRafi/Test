using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using BLL.DTO;
using BLL.Services;

namespace BloodDonationAndHEalthCare.Controllers
{
    public class ProvideHelpController : ApiController
    {
        [HttpPost]
        [Route("api/ProvideHelp/Add")]
        public HttpResponseMessage AddProvideHelp(ProvideHelpDTO provideHelp)
        {
            try
            {
                var addedProvideHelp = ProvideHelpService.AddProvideHelp(provideHelp);
                if (addedProvideHelp != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, addedProvideHelp);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Failed to add ProvideHelp." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }


    }
}

