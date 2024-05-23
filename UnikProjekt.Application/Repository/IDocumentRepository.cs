using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Application.Repository
{
    public interface IDocumentRepository
    {
        Guid AddDocument(Document document);
    }
}
