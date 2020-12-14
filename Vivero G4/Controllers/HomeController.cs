using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vivero_G4.Models;

namespace Vivero_G4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Nosotros()
        {
            return View();
        }

        public IActionResult ComoComprar()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public JsonResult EnviarMail(String cuerpo)
        {
            string mailFrom = "viveronaturalezamistica@gmail.com";
            string mailFromPassword = "peperomero10";
            string mailFromDisplayName = "NM WEB CONSULTA";
            string smtpServerIp = "smtp.gmail.com";
            int smtpServerPort = 587;
            bool smtpServerEnableSsl = true;

            using (var client = new SmtpClient(smtpServerIp, smtpServerPort)
            {
                Credentials = new NetworkCredential(mailFrom, mailFromPassword),
                EnableSsl = smtpServerEnableSsl
            })
            {
                String mailTo = "viveronaturalezamistica@gmail.com";

                var mailMessage = new MailMessage(new MailAddress(mailFrom, mailFromDisplayName, System.Text.Encoding.UTF8), new MailAddress(mailTo))
                {
                    IsBodyHtml = true,
                    Subject = "consulta",
                    Body = cuerpo
                };

                client.Send(mailMessage);
            }

            return Json(true);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
