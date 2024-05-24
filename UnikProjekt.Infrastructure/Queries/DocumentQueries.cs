using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikProjekt.Application.Queries.DTOs;
using UnikProjekt.Application.Queries;
using UnikProjekt.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace UnikProjekt.Infrastructure.Queries
{
    internal class DocumentQueries : IDocumentQueries
    {
        private readonly UnikDbContext _context;

        public DocumentQueries(UnikDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all documents from database
        /// </summary>
        /// <returns>List of documents</returns>
        IEnumerable<DocumentDto> IDocumentQueries.GetAllDocuments()
        {
            return _context.Documents.AsNoTracking()
                .Select(x => new DocumentDto
                {
                    Id = x.Id,
                    DocumentContent = x.DocumentContent,
                    DocumentTitle = x.DocumentTitle,
                    UserId = x.User.Id,
                    DateModified = x.DateModified,
                    RowVersion = x.RowVersion
                })
                .ToList();
        }

        /// <summary>
        /// Gets document by Guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns>First or default document with Id</returns>
        DocumentDto? IDocumentQueries.GetDocumentById(Guid id)
        {
            var document = _context.Documents
                .AsNoTracking()   //LOAD
                .Where(x => x.Id == id)
                .Select(x => new DocumentDto  //TRANSFORM
                {
                    Id = x.Id,
                    DocumentContent = x.DocumentContent,
                    DocumentTitle = x.DocumentTitle,
                    UserId = x.User.Id,
                    DateModified = x.DateModified,
                    RowVersion = x.RowVersion
                })
                .FirstOrDefault();

            return document;  //RETURN
        }

        /// <summary>
        /// Gets document by title
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns>First or default document with Title</returns>
        DocumentDto? IDocumentQueries.GetDocumentByTitle(string searchTerm)
        {
            var document = _context.Documents
                .AsNoTracking()   //LOAD
                .Where(x => x.DocumentTitle.Contains(searchTerm))
                .Select(x => new DocumentDto  //TRANSFORM
                {
                    Id = x.Id,
                    DocumentContent = x.DocumentContent,
                    DocumentTitle = x.DocumentTitle,
                    UserId = x.User.Id,
                    DateModified = x.DateModified,
                    RowVersion = x.RowVersion
                })
                .FirstOrDefault();

            return document;  //RETURN
        }
    }
}
