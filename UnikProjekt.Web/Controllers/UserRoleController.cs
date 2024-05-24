using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Web.Models.DTOs;
using UnikProjekt.Web.ProxyServices;

namespace UnikProjekt.Web.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly IUserServiceProxy _userServiceProxy;

        public UserRoleController(IUserServiceProxy userServiceProxy)
        {
            _userServiceProxy = userServiceProxy;
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
        public async Task<IActionResult> Create(IFormCollection collection, CreateUserRoleDto createUserRoleDto)
        {
            try
            {
                await _userServiceProxy.CreateUserRoleAsync(createUserRoleDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
