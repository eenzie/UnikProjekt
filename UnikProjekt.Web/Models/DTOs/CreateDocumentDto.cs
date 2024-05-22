namespace UnikProjekt.Web.Models.DTOs
{
    public class CreateDocumentDto
    {
        public byte[] DocumentContent { get; set; }
        public string DocumentTitle { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateModified { get; set; }
    }
}
