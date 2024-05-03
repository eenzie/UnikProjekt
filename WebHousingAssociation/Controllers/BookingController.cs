using Microsoft.AspNetCore.Mvc;

namespace WebHousingAssociation.Controllers
{
    public class BookingController : Controller
    {
        //[Authorize(Policy = "SecurityLevel1")]
        public IActionResult Create()
        {
            //Lav logik
            return View("BookingPage");

        }

        // [Authorize(Policy = "SecurityLevel2")]
        public IActionResult Edit(int id)
        {
            // Lav noget logik
            return View();
        }

        //[Authorize(Policy = "SecurityLevel3")]
        public IActionResult Delete(int id)
        {
            // Lav noget logik
            return View();
        }
    }
}
