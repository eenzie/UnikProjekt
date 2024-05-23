using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikProjekt.Application.Queries.DTOs
{
    public class DocumentDto
    {
        public Guid Id { get; set; }
        public byte[] DocumentContent { get; set; }
        public string DocumentTitle { get; set; }
        public Guid UserId { get; set; } 
        public DateTime DateModified { get; set; }
        public byte[] RowVersion { get; set; } = [];
    }
}
