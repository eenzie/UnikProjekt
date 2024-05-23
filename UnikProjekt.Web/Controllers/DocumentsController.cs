using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Web.Models.DTOs;
using UnikProjekt.Web.ProxyServices;

namespace UnikProjekt.Web.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly IUserServiceProxy _userServiceProxy;
        public DocumentsController(IUserServiceProxy userServiceProxy)
        {
            _userServiceProxy = userServiceProxy;
        }

        // GET: DocumentsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DocumentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DocumentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection, CreateDocumentDto createDocumentDto)
        {
            try
            {
                await _userServiceProxy.CreateDocumentAsync(createDocumentDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DocumentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DocumentsController/Edit/5
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

        // GET: DocumentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DocumentsController/Delete/5
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
