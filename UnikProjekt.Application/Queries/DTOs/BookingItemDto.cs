using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikProjekt.Application.Queries.DTOs
{
    public class BookingItemDto
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public decimal? Deposit { get; set; }
        public TimeOnly IntervalStart { get; set; }
        public TimeOnly IntervalEnd { get; set; }
        public int BookingTimeInMinutes { get; set; }
        public int TimeSlots { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
