using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikProjekt.Domain.DomainService;
using UnikProjekt.Domain.Shared;

namespace UnikProjekt.Domain.Entities
{
    public class BookingLine : Entity
    {
        internal BookingLine() : base(Guid.NewGuid()) 
        { 
        }

        internal BookingLine(Guid id, BookingItem bookingItem, DateTime bookingStart, DateTime bookingEnd) : base(id)
        {
            BookingItem = bookingItem;
            BookingStart = bookingStart;
            BookingEnd = bookingEnd;
            ItemPrice = bookingItem.Price;
        }

        public BookingItem BookingItem { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public decimal ItemPrice { get; set; }

        public static BookingLine Create(BookingItem bookingItem, DateTime bookingStart, DateTime bookingEnd, IBookingDomainService bookingDomainService)
        {
            if (bookingItem == null) throw new ArgumentNullException(nameof(bookingItem));
            if (bookingDomainService == null) throw new ArgumentNullException(nameof(bookingDomainService));

            var bookingLine = new BookingLine(Guid.NewGuid(), bookingItem, bookingStart, bookingEnd);
            if (!bookingLine.ValidateBookingDates(bookingStart, bookingEnd))
            {
                throw new ArgumentException("Start of booking must be before end of booking");
            }
            if (bookingDomainService.IsBookingLineOverlapping(bookingLine))
            {
                throw new ArgumentException("Booking overlaps with other booking");
            }
            return bookingLine;
        }

        public void Update(BookingItem bookingItem, DateTime bookingStart, DateTime bookingEnd)
        {
            if (bookingItem == null) throw new ArgumentNullException(nameof(bookingItem));

            this.BookingItem = bookingItem;
            this.BookingStart = bookingStart;
            this.BookingEnd = bookingEnd;
            this.ItemPrice = bookingItem.Price;

            if (!this.ValidateBookingDates(bookingStart, bookingEnd))
            {
                throw new ArgumentException("Start of booking must be before end of booking");
            }
        }

        private bool ValidateBookingDates(DateTime bookingStart, DateTime bookingEnd)
        {
            if (bookingStart >= bookingEnd)
            {
                return false;
            }
            return true;
        }
    }
}
