using Core.Utilities.Results;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Net.Mail;
using TraversalReservationProject.Models;

namespace TraversalReservationProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            try
            {
              

                MimeMessage mimeMessage = new MimeMessage();

                MailboxAddress mailBoxAdressFrom = new MailboxAddress(mailRequest.Name, mailRequest.SenderMail);
                mimeMessage.From.Add(mailBoxAdressFrom);

                mimeMessage.To.Add(new MailboxAddress("User", mailRequest.ReceiverMail));

                mimeMessage.Subject = mailRequest.Subject;
                mimeMessage.Body = new TextPart("Plain") { Text = mailRequest.Body };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.Auto);

                    client.Authenticate("aydinmfatih@gmail.com", "gbon lnlm vkqr iohw");

                    client.Send(mimeMessage);
                    client.Disconnect(true);
                }

                return View();

            }
            catch (Exception ex)
            {
                return BadRequest($"E-posta gönderilirken hata oluştu: {ex.Message} \nStackTrace: {ex.StackTrace} \nInnerException: {ex.InnerException}");
            }
        }
    }
}
