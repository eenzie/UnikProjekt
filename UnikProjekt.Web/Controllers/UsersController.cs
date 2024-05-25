using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Web.Models;
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
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }

        public async Task<IActionResult> Id(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public async Task<IActionResult> Name(string name)
        {
            var user = await _userService.GetUserByNameAsync(name);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        //// GET: UsersController/Details/5
        //[HttpGet]
        //public async Task<IActionResult> Details(Guid id)
        //{
        //    var user = await _userServiceProxy.GetUserByIdAsync(id);
        //    return View("EditDetails", user);
        //}

        //// GET: UsersController/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        //// POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserDto createUserDto)
        {

            if (ModelState.IsValid)
            {
                var user = await _userService.CreateUserAsync(createUserDto);
                if (user != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(createUserDto);
        }

        // GET: UsersController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var editUserDto = new EditUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                MobileNumber = user.MobileNumber,
                Street = user.Street,
                StreetNumber = user.StreetNumber,
                PostCode = user.PostCode,
                City = user.City,
                RowVersion = user.RowVersion,
            };
            return View(editUserDto);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UserViewModel userViewModel)
        {
            if (id != userViewModel.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                // Konverter UserViewModel til EditUserDto
                var editUserDto = new EditUserDto
                {
                    Id = userViewModel.Id,
                    FirstName = userViewModel.FirstName,
                    LastName = userViewModel.LastName,
                    Email = userViewModel.Email,
                    MobileNumber = userViewModel.MobileNumber,
                    Street = userViewModel.Street,
                    StreetNumber = userViewModel.StreetNumber,
                    PostCode = userViewModel.PostCode,
                    City = userViewModel.City,
                    RowVersion = userViewModel.RowVersion
                };

                var roleId = await _userService.EditUserAsync(id, editUserDto);
                if (roleId != Guid.Empty)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(userViewModel);
        }

        //[HttpGet]
        public ActionResult Search(string id)
        {
            if (Guid.TryParse(id, out Guid userId))
            {
                var user = _userService.GetUserByIdAsync(userId);
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





