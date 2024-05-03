using Microsoft.AspNetCore.Mvc;

namespace WebHousingAssociation.Controllers
{
    public class BoardRoleController : Controller
    {
        public IActionResult Create()
        {

            //var model = new BoardRole
            //{
            //    RoleName = "Formand",
            //    Residents = new List<string> { "Beboer 1", "Beboer 2", "Beboer 3" },
            //    LastModified = DateTime.Now
            //};

            return View("BoardRolePage"/*, model*/);
        }
    }
}
