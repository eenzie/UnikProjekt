using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Web.Models;
using UnikProjekt.Web.Models.DTOs;
using UnikProjekt.Web.ProxyServices;

namespace UnikProjekt.Web.Controllers
{
    public class UsersController : Controller
    {
        //private readonly UserService _userService;
        private readonly IUserServiceProxy _userServiceProxy;

        public UsersController(/*UserService userService,*/ IUserServiceProxy userServiceProxy)
        {
            //_userService = userService;
            _userServiceProxy = userServiceProxy;

        }

        //GET: UsersController
        public async Task<IActionResult> Index()
        {
            var users = await _userServiceProxy.GetAllUsersAsync();
            return View(users);
        }

        public async Task<IActionResult> Id(Guid id)
        {
            var user = await _userServiceProxy.GetUserByIdAsync(id);
            return View(user);
        }

        public async Task<IActionResult> Name(string name)
        {
            var user = await _userServiceProxy.GetUserByNameAsync(name);
            return View(user);
        }

        //// GET: UsersController/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var user = await _userServiceProxy.GetUserByIdAsync(id);
            return View("EditDetails", user);
        }

        //// GET: UsersController/Create
        [Authorize]
        public async Task<IActionResult> Create(CreateUserDto createUserDto)
        {
            return View();
        }

        //// POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection, CreateUserDto createUserDto)
        {
            try
            {
                await _userServiceProxy.CreateUserAsync(createUserDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            //var user = await _userServiceProxy.GetUserById(id);
            //return View(user);
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, /*IFormCollection collection,*/ UserViewModel userViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(userViewModel);
                }

                var updatedUser = _userServiceProxy.EditUserAsync(id, userViewModel);
                if (updatedUser != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Failed to update user.");
                    return View(userViewModel);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An unexpected error occurred: " + ex.Message);
                return View(userViewModel);
            }
        }

        //[HttpGet]
        public ActionResult Search(string id)
        {
            if (Guid.TryParse(id, out Guid userId))
            {
                var user = _userServiceProxy.GetUserByIdAsync(userId);
                return View("EditDetails", user);
            }
            else
            {
                return RedirectToAction(nameof(Index));
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
