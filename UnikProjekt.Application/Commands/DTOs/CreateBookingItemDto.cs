using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikProjekt.Application.Commands.DTOs
{
    public class CreateBookingItemDto
    {
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public decimal Deposit { get; set; }
        public TimeOnly IntervalStart { get; set; }
        public TimeOnly IntervalEnd { get; set; }
        public int BookingTimeInMinutes { get; set; }
    }
}
