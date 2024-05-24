using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikProjekt.Domain.DomainService;
using UnikProjekt.Domain.Entities;
using UnikProjekt.Infrastructure.Database;

namespace UnikProjekt.Infrastructure.DomainServices;

public class BookingDomainService : IBookingDomainService
{
    private readonly UnikDbContext _context;

    public BookingDomainService(UnikDbContext context)
    {
        _context = context;
    }

    public IEnumerable<BookingLine> OtherBookings(Booking booking)
    {
        //TODO: Check how this works, this can't possibly be correct
        //Check for BookingItem Id specifically in Where
        //Booking is not set in BookingLine
        //return _context.Bookings.AsNoTracking()
        //    .SelectMany(x => x.Items).Where(x => x.Booking.Id != booking.Id && x.BookingItem.Id == booking.Items).ToList();

        return new List<BookingLine>();
    }
}

