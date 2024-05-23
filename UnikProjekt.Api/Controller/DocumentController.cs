using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Application.Commands;
using UnikProjekt.Application.Commands.DTOs;
using UnikProjekt.Application.Queries;
using UnikProjekt.Application.Queries.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnikProjekt.Api.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentCommand _documentCommand;
        private readonly IDocumentQueries _documentQueries;

        public DocumentController(IDocumentCommand documentCommand, IDocumentQueries documentQueries)
        {
            _documentCommand = documentCommand;
            _documentQueries = documentQueries;
        }

        // GET: api/<DocumentController>
        [HttpGet]
        public ActionResult<IEnumerable<DocumentDto>> Get()
        {
            var result = _documentQueries.GetAllDocuments();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET: Document/5
        [HttpGet("{id:guid}", Name = "GetDocumentById")]
        public ActionResult<DocumentDto> GetDocumentById(Guid id)
        {
            var result = _documentQueries.GetDocumentById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        //GET: User/JohnDoe
        [HttpGet("{title}", Name = "GetDcoumentByTitle")]
        public IActionResult GetDocumentByTitle(string name)
        {
            var result = _documentQueries.GetDocumentByTitle(name);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        //POST: User
        [HttpPost(Name = "Create")]
        public IActionResult Create([FromBody] CreateDocumentDto document)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var documentToCreate = new CreateDocumentDto
            {
                DocumentContent = document.DocumentContent,
                DocumentTitle = document.DocumentTitle,
                UserId = document.UserId,
                DateModified = document.DateModified,
            };

            var documentId = _documentCommand.CreateDocument(documentToCreate);

            if (documentId == Guid.Empty)
            {
                return NotFound();
            }

            return CreatedAtAction("Create", new { Id = documentId }, documentToCreate);
        }
    }
}
