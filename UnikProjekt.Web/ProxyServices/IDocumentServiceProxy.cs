using UnikProjekt.Web.Models.DTOs;

namespace UnikProjekt.Web.ProxyServices
{
    public interface IDocumentServiceProxy
    {
        Task<DocumentDto> CreateDocumentAsync(DocumentDto documentDto);
    }
}
