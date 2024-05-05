using Microsoft.AspNetCore.Mvc;

namespace WebHousingAssociation.Controllers
{
    public class AdministratorController : Controller
    {
        public IActionResult Index()
        {
            return View("AdministratorHomePage");
        }

        public IActionResult CreateUser()
        {
            return View("CreateUserPage");
        }

        public IActionResult CreateUserRole()
        {
            return View("CreateUserRolePage");
        }

        public IActionResult AdministratorsTaskMenu()
        {
            return View("AdministratorTaskMenuPage");
        }

        //public IActionResult EditUser()
        //{
        //TODO: Anh der skal laves en GetUserById metode i Application laget før den her virker
        //var user = GetUserById(id);

        //// Tjek om brugeren findes
        //if (user == null)
        //{
        //    return NotFound();
        //}

        //return View("EditUserPage", user);
        //}
    }


}
