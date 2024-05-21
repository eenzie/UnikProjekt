using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikProjekt.Application.Queries;
using UnikProjekt.Application.Queries.DTOs;
using UnikProjekt.Infrastructure.Database;

namespace UnikProjekt.Infrastructure.Queries
{
    public class BookingQueries : IBookingQueries
    {
        private readonly UnikDbContext _context;

        public BookingQueries(UnikDbContext context)
        {
            _context = context;
        }

        IEnumerable<BookingDto> IBookingQueries.GetAllBookings()
        {
            return _context.Bookings.AsNoTracking()
            .Select(x => new BookingDto
            {
                
            })
            .ToList();
        }

        BookingDto? IBookingQueries.GetBookingById(Guid bookingId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<BookingDto> IBookingQueries.GetBookingByUser(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
