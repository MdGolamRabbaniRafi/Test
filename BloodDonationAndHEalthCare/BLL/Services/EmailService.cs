using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static BLL.Services.EmailService;
using DAL.Interface;

namespace BLL.Services
{
    public class EmailService:IEmail
    {
       
            private readonly string _smtpServer = "smtp.gmail.com.";
            private readonly int _smtpPort =587;
            private readonly string _smtpUsername= "mdfahadkhan01701@gmail.com";
            private readonly string _smtpPassword= "arkdnbjcfpsplsrk";

            public EmailService(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword)
            {
                _smtpServer = smtpServer;
                _smtpPort = smtpPort;
                _smtpUsername = smtpUsername;
                _smtpPassword = smtpPassword;
            }

            public void SendEmail(string to, string subject, string body)
            {
                using (var message = new MailMessage(_smtpUsername, to))
                {
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = true;

                    using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
                    {
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                        smtpClient.EnableSsl = true;

                        smtpClient.Send(message);
                    }
                }
            }
        
    }
}
