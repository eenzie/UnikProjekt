using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Web.Models.DTOs;
using UnikProjekt.Web.Services;

namespace UnikProjekt.Web.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly DocumentService _documentService;
        public DocumentsController(DocumentService documentService)
        {
            _documentService = documentService;
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
                await _documentService.CreateDocumentAsync(createDocumentDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Der opstod en fejl under opload af dokumentet. Prøv igen");
                return View(createDocumentDto);
            }
        }
    }
}
