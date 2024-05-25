using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Web.Models.DTOs;
using UnikProjekt.Web.Services;

namespace UnikProjekt.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleService _roleService;

        public RolesController(RoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: RolesController
        //Listing all the roles created by admin
        public async Task<IActionResult> Index()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return View(roles);
        }

        // GET: RolesController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        public async Task<IActionResult> Name(string name)
        {
            var role = await _roleService.GetRoleByNameAsync(name);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        // GET: RolesController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRoleDto createRoleDto)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleService.CreateRoleAsync(createRoleDto);
                if (role != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(createRoleDto);
        }

        // GET: RolesController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            var editRoleDto = new EditRoleDto
            {
                Id = role.Id,
                RoleName = role.RoleName,
                RowVersion = role.RowVersion
            };
            return View(editRoleDto);
        }

        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditRoleDto editRoleDto)
        {
            if (id != editRoleDto.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var roleId = await _roleService.EditRoleAsync(id, editRoleDto);
                if (roleId != Guid.Empty)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(editRoleDto);
        }

        // GET: RolesController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        // POST: RolesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
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
