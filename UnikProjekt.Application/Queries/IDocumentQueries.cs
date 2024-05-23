using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikProjekt.Application.Queries.DTOs;

namespace UnikProjekt.Application.Queries
{
    public interface IDocumentQueries
    {
        IEnumerable<DocumentDto> GetAllDocuments();
        DocumentDto? GetDocumentById(Guid id);
        DocumentDto? GetDocumentByTitle(string title);
    }
}
