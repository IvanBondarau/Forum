using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Forum.Services.Implementatios
{
    public class MailService : IMailService
    {
        private readonly SmtpClient smtpClient;

        public MailService()
        {
             smtpClient = new SmtpClient("smtp.gmail.com", 587);
             smtpClient.Credentials = new System.Net.NetworkCredential("testwebforum333@gmail.com", "#MRwS5x%D*2U&jMQjp");
             smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
             smtpClient.EnableSsl = true;
           /* smtpClient.UseDefaultCredentials = false;*/

        }


        public void SendVerificationMail(string email, string verificationString)
        {
            MailMessage mailMessage = new MailMessage("testwebforum333@gmail.com", email);
            mailMessage.Subject = "Account verification";
            mailMessage.Body = "Your verification link: " + verificationString;
            smtpClient.Send(mailMessage);
        }
    }
}
