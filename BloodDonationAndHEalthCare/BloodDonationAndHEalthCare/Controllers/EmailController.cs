
﻿/*using BLL.DTO;
=======
/*﻿using BLL.DTO;
using BLL.Services; // Assuming you have an EmailService in this namespace
using BloodDonationAndHEalthCare.Models;
using DAL.Interface;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace BloodDonationAndHEalthCare.Controllers
{
    public class EmailController : ApiController
    {
        private readonly IEmail _emailService;

        public EmailController(IEmail emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        [Route("api/SendEmail")]
        public HttpResponseMessage SendEmail([FromBody] EmailDTO emailModel)
        {
            try
            {
               
                if (emailModel == null || string.IsNullOrEmpty(emailModel.To) || string.IsNullOrEmpty(emailModel.Subject) || string.IsNullOrEmpty(emailModel.Body))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid email data");
                }

                _emailService.SendEmail(emailModel.To, emailModel.Subject, emailModel.Body);

                return Request.CreateResponse(HttpStatusCode.OK, "Email sent successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while sending the email");
            }
        }
    }
}*/
