using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Web.Models;
using UnikProjekt.Web.Services;

namespace UnikProjekt.Web.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var emailForm = new EmailViewModel();
            return View(emailForm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string recipientEmail, string subject, string message)
        {
            if (string.IsNullOrEmpty(recipientEmail) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(message))
            {
                return BadRequest("Modtagerens e-mail, emne og besked skal udfyldes.");
            }

            await _emailService.SendEmailAsync(recipientEmail, subject, message);

            //Omdiriger til en bekræftelsesside eller vis en bekræftelsesbesked
            return RedirectToAction("EmailSent");
        }


        public IActionResult EmailSent()
        {

            return View();
        }
    }
}
