using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikProjekt.Domain.Shared;

namespace UnikProjekt.Domain.Entities
{
    public class BookingLine : Entity
    {
        internal BookingLine() { }

        public BookingLine(Guid id, BookingItem bookingItem, DateTime bookingStart, DateTime bookingEnd)
        {
            BookingItem = bookingItem;
            BookingStart = bookingStart;
            BookingEnd = bookingEnd;
            ItemPrice = bookingItem.Price;
        }

        public Booking Booking { get; set; }
        public BookingItem BookingItem { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public decimal ItemPrice { get; set; }

        public static BookingLine Create(BookingItem bookingItem, DateTime bookingStart, DateTime bookingEnd)
        {
            if (bookingItem == null) throw new ArgumentNullException(nameof(bookingItem));

            var bookingLine = new BookingLine(Guid.NewGuid(), bookingItem, bookingStart, bookingEnd);
            if (!bookingLine.ValidateBookingDates(bookingStart, bookingEnd))
            {
                throw new ArgumentException("Start of booking must be before end of booking");
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
            if (bookingStart > bookingEnd)
            {
                return false;
            }
            return true;
        }

        private bool IsBookingOverlapping(List<BookingLine> bookingLines)
        {
            //TODO: SORT THIS OUT
            return true;
        }
    }
}
