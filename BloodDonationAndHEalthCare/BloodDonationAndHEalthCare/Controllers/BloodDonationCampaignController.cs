using BLL.DTO;
using BLL.DTOs;
using BLL.Services;
using BloodDonationAndHEalthCare.Auth;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BloodDonationAndHEalthCare.Controllers
{
    [EnableCors("*", "*", "*")]
    public class BloodDonationCampaignController : ApiController
    {
        [Logged]
        [HttpPost]
        [Route("api/BloodDonationCampaign/AddCampaign")]
        public HttpResponseMessage AddBloodDonationCampaign(BloodDonationCampaignDTO campaign)
        {
            try
            {
                var addedCampaign = BloodDonationCampaignService.AddBloodDonationCampaign(campaign);
                return Request.CreateResponse(HttpStatusCode.OK, addedCampaign);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [Logged]
        [HttpPost]
        [Route("api/BloodDonationCampaign/UpdateCampaign/{campaignId}")]
        public HttpResponseMessage UpdateBloodDonationCampaign(int campaignId, BloodDonationCampaignDTO campaign)
        {
            try
            {
                var updatedCampaign = BloodDonationCampaignService.UpdateBloodDonationCampaign(campaignId, campaign);

                if (updatedCampaign != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, updatedCampaign);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Blood donation campaign not found." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [Logged]
        [HttpPost]
        [Route("api/BloodDonationCampaign/DeleteCampaign/{campaignId}")]
        public HttpResponseMessage DeleteBloodDonationCampaign(int campaignId)
        {
            try
            {
                bool isDeleted = BloodDonationCampaignService.DeleteBloodDonationCampaign(campaignId);

                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Blood donation campaign deleted successfully." });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Blood donation campaign not found." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [Logged]
        [HttpGet]
        [Route("api/GetTotalAvailableCampaigns")]
        public HttpResponseMessage GetTotalAvailableCampaigns()
        {
            try
            {
                var totalAvailableCampaigns = BloodDonationCampaignService.GetAllBloodDonationCampaigns();

                if (totalAvailableCampaigns.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, totalAvailableCampaigns);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "No available campaigns found." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [Logged]
        [HttpPost]
        [Route("api/JoinBloodDonationCampaign/{userId}/{campaignId}")]
        public HttpResponseMessage JoinBloodDonationCampaign(int userId, int campaignId)
        {
            try
            {
                //var token = ActionContext.Request.Headers.Authorization;
                //var data = BloodDonationCampaignService.JoinBloodDonationCampaign( token.ToString());
                bool isJoined = UserService.JoinBloodDonationCampaign(userId, campaignId);

                if (isJoined)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "User joined the blood donation campaign successfully." });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "User could not join the blood donation campaign." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
    }
}

