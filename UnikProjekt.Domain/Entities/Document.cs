using UnikProjekt.Domain.Shared;

namespace UnikProjekt.Domain.Entities
{
    public class Document : Entity
    {
        internal Document()
        {

        }

        internal Document(Guid guid, byte[] documentContent, string documentTitle, User author, DateTime dateModified)
        {
            DocumentContent = documentContent;
            DocumentTitle = documentTitle;
            User = author;
            DateModified = dateModified;
        }

        public byte[] DocumentContent { get; set; }

        public string DocumentTitle { get; set; }
        public User User { get; set; }

        public DateTime DateModified { get; set; }

        public static Document Create(byte[] documentContent, string documentTitle, User user, DateTime dateModified)
        {
            if (documentContent == null) throw new ArgumentNullException(nameof(documentContent));
            if (documentTitle == null) throw new ArgumentNullException(nameof(documentTitle));
            if (user == null) throw new ArgumentNullException(nameof(user));
            var document = new Document(Guid.NewGuid(), documentContent, documentTitle, user, dateModified);

            return document;
        }
    }
}
