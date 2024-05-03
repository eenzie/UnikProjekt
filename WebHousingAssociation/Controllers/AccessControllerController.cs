using Microsoft.AspNetCore.Mvc;

namespace WebHousingAssociation.Controllers
{
    public class AccessControllerController : Controller
    {
        //[Authorize(Policy = "SecurityLevel1")]
        public async Task<IActionResult> SecurityLevel1()
        {
            return View("SecurityLevel1View");
        }

        //[Authorize(Policy = "SecurityLevel2")]
        public async Task<IActionResult> SecurityLevel2()
        {
            return View("SecurityLevel2View");
        }

        //[Authorize(Policy = "SecurityLevel3")]
        public async Task<IActionResult> SecurityLevel3()
        {

            return View("SecurityLevel3View");
        }
    }
}
