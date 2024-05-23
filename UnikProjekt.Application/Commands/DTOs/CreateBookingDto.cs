using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikProjekt.Application.Queries.DTOs;
using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Application.Commands.DTOs
{
    public class CreateBookingDto
    {
        public Guid UserId { get; set; }
        public DateTime DateBooked { get; set; }
        public List<CreateBookingLineDto> Items { get; set; }
        public string BookingComment { get; set; }
    }
} 
