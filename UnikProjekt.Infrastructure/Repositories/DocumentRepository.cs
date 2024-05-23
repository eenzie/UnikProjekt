using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikProjekt.Application.Repository;
using UnikProjekt.Domain.Entities;
using UnikProjekt.Infrastructure.Database;

namespace UnikProjekt.Infrastructure.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly UnikDbContext _context;
        public DocumentRepository(UnikDbContext context) 
        {
            _context = context;
        }

        Guid IDocumentRepository.AddDocument(Document document)
        {
            _context.Documents.Add(document);
            _context.SaveChanges();
            return document.Id;
        }
    }
}
