using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikProjekt.Application.Commands.DTOs
{
    public class UpdateBookingDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateBooked { get; set; }
        public List<UpdateBookingLineDto> Items { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
