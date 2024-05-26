using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<IActionResult> Index(string email, string subject, string message)
        {
            await _emailService.SendEmailAsync(email, subject, message);
            return View();
        }
    }
}
