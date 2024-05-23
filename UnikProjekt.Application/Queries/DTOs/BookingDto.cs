using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Application.Queries.DTOs
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public UserDto User { get; set; }
        public DateTime DateBooked { get; set; }
        public List<BookingLineDto> Items { get; set; }
        public string BookingComment { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalPrice { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
