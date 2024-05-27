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

    public bool IsBookingLineOverlapping(BookingLine bookingLine)
    {
        return _context.BookingLines.AsNoTracking()
            .Any(other => bookingLine.BookingItem.Id == other.BookingItem.Id
                && (bookingLine.BookingStart >= other.BookingStart && bookingLine.BookingStart <= other.BookingEnd
                ||  bookingLine.BookingEnd <= other.BookingEnd && bookingLine.BookingEnd >= other.BookingStart
                ||  bookingLine.BookingStart <= other.BookingStart && bookingLine.BookingEnd >= other.BookingEnd));
    }
}

