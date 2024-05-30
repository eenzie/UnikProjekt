using UnikProjekt.Web.Models.DTOs;

namespace UnikProjekt.Web.ProxyServices
{
    public class DocumentServiceProxy : IDocumentServiceProxy
    {
        private readonly HttpClient _httpClient;

        public DocumentServiceProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task<DocumentDto> IDocumentServiceProxy.CreateDocumentAsync(DocumentDto documentDto)
        {
            var httpResponseMessage = await _httpClient.PostAsJsonAsync("Document", documentDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadFromJsonAsync<DocumentDto>();
            }
            else
            {
                throw new Exception("Failed to upload document");
            }
        }
    }
}

