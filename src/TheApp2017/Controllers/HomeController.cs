using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using TheApp2017.Model;

namespace TheApp2017.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpPost]
        public async void SubmitMessage(SubmitMessageModel formData)
        {
            bool success = true;
            try
            {
                await SendEmailAsync(formData.Email, formData.Subject, formData.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                success = false;
            }


        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("message", email));
            emailMessage.To.Add(new MailboxAddress("", "freeman.zhou039@gmail.com"));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            using (var client = new SmtpClient())
            {

                client.Connect("smtp.gmail.com", 587, false);
                // Note: only needed if the SMTP server requires authentication 
                // Error 5.5.1 Authentication  
                //client.Authenticate("freeman.zhou039@gmail.com", "zzj030309");
                client.Send(emailMessage);
                Console.WriteLine("The mail has been sent successfully !!");
                Console.ReadLine();
                client.Disconnect(true);


                //client.LocalDomain = "smtp.gmail.com";
                //await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.None).ConfigureAwait(false);
                //await client.SendAsync(emailMessage).ConfigureAwait(false);
                //await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
