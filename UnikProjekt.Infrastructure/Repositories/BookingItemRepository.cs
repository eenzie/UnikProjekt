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
    public class BookingItemRepository : IBookingItemRepository
    {
        private readonly UnikDbContext _context;

        public BookingItemRepository(UnikDbContext context)
        {
            _context = context;
        }

        BookingItem IBookingItemRepository.GetBookingItem(Guid bookingItemId)
        {
            return _context.BookingItems.Find(bookingItemId) ?? throw new Exception("Booking Item not found");
        }
        Guid IBookingItemRepository.AddBookingItem(BookingItem bookingItem)
        {
            _context.BookingItems.Add(bookingItem);
            _context.SaveChanges();
            return bookingItem.Id;
        }

        void IBookingItemRepository.UpdateBookingItem(BookingItem bookingItem, byte[] rowVersion)
        {
            _context.Entry(bookingItem).Property(p => p.RowVersion).OriginalValue = rowVersion;
            _context.SaveChanges();
        }
    }
}
