using Microsoft.AspNetCore.Mvc;

namespace WebHousingAssociation.Controllers
{
    public class AdministratorController : Controller
    {
        public IActionResult Index()
        {
            return View("AdministratorHomePage");
        }
    }
}
