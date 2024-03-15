using BLL.DTO;
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
    public class ServiceProviderController : ApiController
    {
        [Logged]
        [HttpGet]
        [Route("api/ServiceProvider/PendingRequests")]
        public HttpResponseMessage GetPendingDonationRequests()
        {
            try
            {
                var pendingDonationRequests = DonationService.GetPendingDonationRequests();

                if (pendingDonationRequests.Count == 0)
                {
                    // No pending requests, return a message
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "No pending donation requests." });
                }

                return Request.CreateResponse(HttpStatusCode.OK, pendingDonationRequests);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        
        [HttpPost]
        [Route("api/ServiceProvider/ApproveDonation/{donationId}")]
        public HttpResponseMessage ApproveDonation(int donationId)
        {
            try
            {
                bool isApproved = DonationService.ApproveDonationRequest(donationId);

                if (isApproved)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Donation request approved successfully." });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Donation request not found or already approved." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [Logged]
        [HttpGet]
        [Route("api/ServiceProvider/ApprovedDonations")]
        public HttpResponseMessage GetApprovedDonations()
        {
            try
            {
                var approvedDonations = DonationService.GetApprovedDonations();

                if (approvedDonations.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "No approved donations available." });
                }

                return Request.CreateResponse(HttpStatusCode.OK, approvedDonations);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        
        [HttpPost]
        [Route("api/ServiceProvider/DeleteDonation/{donationId}")]
        public HttpResponseMessage DeleteDonationRequest(int donationId)
        {
            try
            {
                bool isDeleted = DonationService.DeleteDonationRequest(donationId);

                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Donation deleted successfully." });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Donation not found." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }








    }
}
