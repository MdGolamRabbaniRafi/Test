using BLL.DTO;
using BLL.DTOs;
using BLL.Services;
using BloodDonationAndHEalthCare.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BloodDonationAndHEalthCare.Controllers
{

    [EnableCors("*", "*", "*")]
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("api/User/add")]
        public HttpResponseMessage AddUser(UserDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var data = UserService.AddUserService(user);
                return Request.CreateResponse(HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [Logged]
        [HttpGet]
        [Route("api/User/{userId}")]
        public HttpResponseMessage GetUser(int userId)
        {
            try
            {
                var data = UserService.GetUser(userId);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [Logged]
        [HttpGet]
        [Route("api/AllUser")]
        public HttpResponseMessage GetAllUser()
        {
            try
            {
                var data = UserService.GetAllUser();

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }


        [Logged]
        [HttpPost]
        [Route("api/User/update/{userId}")]
        public HttpResponseMessage UpdateUser(int userId, [FromBody] UserDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var updatedUser = UserService.UpdateUserService(userId, user);

                if (updatedUser != null)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, updatedUser);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "User not found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [Logged]
        [HttpDelete]
        [Route("api/User/delete/{userId}")]
        public HttpResponseMessage DeleteUser(int userId)
        {
            try
            {
                var isSuccess = UserService.DeleteUserService(userId);

                if (isSuccess)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "User deleted successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [Logged]
        [HttpPost]
        [Route("api/User/Login")]
        public HttpResponseMessage LoginUser(UserDTO user)
        {
            try
            {

                var data = AuthService.Authenticate(user.Email, user.Password);
                return Request.CreateResponse(HttpStatusCode.Created, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [Logged]
        [HttpPost]
        [Route("api/User/Donate")]
        public HttpResponseMessage Donate(DonationDTO donationDTO)
        {
            try
            {
                var token = ActionContext.Request.Headers.Authorization;
                var data = DonationService.CreateDonationRequest(donationDTO, token.ToString());
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

               

                if (data != null)
                {
                   
                    var notificationMessage = $"Donation request created successfully";
                    

                    return Request.CreateResponse(HttpStatusCode.Created, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Failed to create donation request" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }




        [Logged]
        [HttpGet]
        [Route("api/User/ApprovedDonations")]
        public HttpResponseMessage GetApprovedDonations()
        {
            try
            {
                var approvedDonations = DonationService.GetApprovedDonations();

                if (approvedDonations.Count == 0)
                {
                    // No approved donations, return a message
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "No approved donations." });
                }

                return Request.CreateResponse(HttpStatusCode.OK, approvedDonations);
            }
            catch (Exception)
            {
                // Log the exception for troubleshooting
                // You may also want to notify the user about the error
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "An error occurred while retrieving approved donations." });
            }
        }
       










    }
}
