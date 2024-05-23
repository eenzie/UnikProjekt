using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikProjekt.Application.Repository;
using UnikProjekt.Domain.Entities;
using UnikProjekt.Infrastructure.Database;

namespace UnikProjekt.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly UnikDbContext _context;

        public BookingRepository(UnikDbContext context)
        {
            _context = context;
        }

        Booking IBookingRepository.GetBooking(Guid bookingId)
        {
            return _context.Bookings.Find(bookingId) ?? throw new Exception("Booking not found");
        }
        Guid IBookingRepository.AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return booking.Id;
        }

        void IBookingRepository.UpdateBooking(Booking booking, byte[] rowVersion)
        {
            _context.Entry(booking).Property(p => p.RowVersion).OriginalValue = rowVersion;
            _context.SaveChanges();
        }

    }
}
