using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Web.Models.DTOs;
using UnikProjekt.Web.Services;

namespace UnikProjekt.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        //GET: UsersController
        public ActionResult Index()
        {
            var users = _userService.GetAllUsers();

            return View(users);
        }

        public ActionResult Id(string id)
        {
            var user = _userService.GetUserById(id);
            return View(user);
            //if (!Guid.TryParse(id, out Guid userId))
            //{
            //    return RedirectToAction("Error"); 
            //}

            //var user = _userService.GetUserById(userId);
            //return View(user);
        }

        public ActionResult Name(string name)
        {
            var user = _userService.GetUserByName(name);
            return View(user);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create(CreateUserDto createUserDto)
        {
            _userService.CreateUser(createUserDto);

            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
