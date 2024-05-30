using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Web.Models;
using UnikProjekt.Web.Models.DTOs;
using UnikProjekt.Web.Services;

namespace UnikProjekt.Web.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly UserRoleService _userRoleService;


        public UserRoleController(UserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        // GET: UserRoleController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserRoleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserRoleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserRoleDto createUserRoleDto)
        {
            if (ModelState.IsValid)
            {
                var userRole = await _userRoleService.CreateUserRoleAsync(createUserRoleDto);
                if (userRole != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Kunne ikke oprette en ny rolle til brugeren");

                }
            }
            var userRoleViewModel = new UserRoleViewModel
            {
                StartDate = createUserRoleDto.StartDate,
                EndDate = createUserRoleDto.EndDate
            };

            return View(userRoleViewModel);
        }

        // GET: UserRoleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserRoleController/Edit/5
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

        // GET: UserRoleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserRoleController/Delete/5
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
