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

        //// GET: UsersController/Create
        ///Hvis Authentication og Authorization havde virket
        //[Authorize]
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
                else
                {
                    ModelState.AddModelError("", "Kunne ikke oprette en ny bruger");
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
                ModelState.AddModelError("", "Kunne ikke finde brugeren.");
                return NotFound();
            }

            ModelState.Remove("RowVersion");

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
        public async Task<IActionResult> Edit(Guid id, EditUserDto editUserDto)
        {

            try
            {
                var userId = await _userService.EditUserAsync(id, editUserDto);
                if (userId != Guid.Empty)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Brugeren blev ikke redigeret.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Der opstod en uventet fejl: " + ex.Message);
            }

            return View(editUserDto);
        }


        public async Task<IActionResult> Search(string name)
        {
            // Validere navnet, om det er gyldigt eller ej.
            if (string.IsNullOrEmpty(name))
            {
                return RedirectToAction(nameof(Index));
            }

            var users = await _userService.GetUserByNameAsync(name);

            if (users == null || !users.Any())
            {
                return NotFound("Brugeren findes ikke i listen.");
            }

            return View("SearchResults", users);
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





