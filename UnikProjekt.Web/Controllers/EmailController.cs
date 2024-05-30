using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Web.Models;
using UnikProjekt.Web.Services;

namespace UnikProjekt.Web.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<EmailController> _logger;

        public EmailController(IEmailService emailService, ILogger<EmailController> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var emailForm = new EmailViewModel();
            _logger.LogInformation("Email retrieved in {ActionName}", nameof(Index));
            return View(emailForm);

        }

        [HttpPost]
        public async Task<IActionResult> Create(string recipientEmail, string subject, string message)
        {
            if (string.IsNullOrEmpty(recipientEmail) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(message))
            {
                _logger.LogWarning("Email failed due to missing fields in {ActionName}", nameof(Create));
                return BadRequest("Modtagerens e-mail, emne og besked skal udfyldes.");
            }

            await _emailService.SendEmailAsync(recipientEmail, subject, message);

            return RedirectToAction("EmailSent");
        }


        public IActionResult EmailSent()
        {

            return View();
        }
    }
}
