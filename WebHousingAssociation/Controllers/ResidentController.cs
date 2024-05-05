using Microsoft.AspNetCore.Mvc;

namespace WebHousingAssociation.Controllers
{
    public class ResidentController : Controller
    {
        public IActionResult Index()
        {
            return View("ResidentTaskMenuPage");
        }
    }
}
