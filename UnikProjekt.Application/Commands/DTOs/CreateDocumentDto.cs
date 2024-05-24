using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikProjekt.Application.Commands.DTOs
{
    public class CreateDocumentDto
    {
        public byte[] DocumentContent { get; set; }
        public string DocumentTitle { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateModified { get; set; }
    }
}
