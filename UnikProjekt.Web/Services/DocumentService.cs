using UnikProjekt.Web.Models;
using UnikProjekt.Web.Models.DTOs;
using UnikProjekt.Web.ProxyServices;

namespace UnikProjekt.Web.Services
{
    public class DocumentService
    {
        private readonly IDocumentServiceProxy _documentServiceProxy;

        public DocumentService(IDocumentServiceProxy documentServiceProxy)
        {
            _documentServiceProxy = documentServiceProxy;
        }

        public async Task<DocumentViewModel> CreateDocumentAsync(CreateDocumentDto createDocumentDto)
        {
            //var documentDto = await _documentServiceProxy.CreateDocumentAsync(createDocumentDto);
            //return new DocumentViewModel
            //{
            //    DocumentContent = documentDto.DocumentContent,
            //    DocumentTitle = documentDto.DocumentTitle,
            //    UserId = documentDto.UserId,
            //    DateModified = documentDto.DateModified,
            //};

            // Konverter IFormFile til byte-array
            byte[] documentBytes;
            using (var memoryStream = new MemoryStream())
            {
                await createDocumentDto.DocumentContent.CopyToAsync(memoryStream);
                documentBytes = memoryStream.ToArray();
            }

            // Opret DocumentDto med byte-array data
            var documentDto = new DocumentDto
            {
                DocumentContent = documentBytes,
                DocumentTitle = createDocumentDto.DocumentTitle,
                UserId = createDocumentDto.UserId,
                DateModified = createDocumentDto.DateModified
            };

            // Send DocumentDto til backend via API'en og få den oprettet dokument
            var createdDocumentDto = await _documentServiceProxy.CreateDocumentAsync(documentDto);

            // Konverter byte[] tilbage til IFormFile til brug i DocumentViewModel
            IFormFile formFile;
            using (var stream = new MemoryStream(createdDocumentDto.DocumentContent))
            {
                formFile = new FormFile(stream, 0, createdDocumentDto.DocumentContent.Length, "name", "filename");
            }

            // Opret DocumentViewModel med data fra oprettet DocumentDto
            return new DocumentViewModel
            {
                DocumentContent = formFile,
                DocumentTitle = createdDocumentDto.DocumentTitle,
                UserId = createdDocumentDto.UserId,
                DateModified = createdDocumentDto.DateModified,
            };
        }
    }
}


