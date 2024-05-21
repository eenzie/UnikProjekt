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

        public BookingLine(Guid id, BookingLineItem bookingLineItem, int quantity, DateTime bookingStart, DateTime bookingEnd)
        {
            // Pre-conditions
            
            BookingLineItem = bookingLineItem;
            Quantity = quantity;
            BookingStart = bookingStart;
            BookingEnd = bookingEnd;

            // Logic

            var totalPrice = CalculateTotalPrice(BookingLineItem, quantity);

            // Post-conditions

            TotalPrice = totalPrice;
        }

        public BookingLineItem BookingLineItem { get; set; }
        public int Quantity { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public decimal TotalPrice { get; set; }

        public static BookingLine Create(BookingLineItem bookingLineItem, int quantity, DateTime bookingStart, DateTime bookingEnd)
        {
            if (bookingLineItem == null) throw new ArgumentNullException(nameof(bookingLineItem));
            if (quantity == null) throw new ArgumentNullException(nameof(quantity));

            var bookingLine = new BookingLine(Guid.NewGuid(), bookingLineItem, quantity, bookingStart, bookingEnd);

            return bookingLine;
        }

        public void Update(BookingLineItem bookingLineItem, int quantity, DateTime bookingStart, DateTime bookingEnd)
        {
            if (bookingLineItem == null) throw new ArgumentNullException(nameof(bookingLineItem));
            if (quantity == null) throw new ArgumentNullException(nameof(quantity));

            this.BookingLineItem = bookingLineItem;
            this.Quantity = quantity;
            this.BookingStart = bookingStart;
            this.BookingEnd = bookingEnd;

            TotalPrice = CalculateTotalPrice(BookingLineItem, quantity);
        }
        private decimal CalculateTotalPrice(BookingLineItem bookingLineItem, int quantity)
        {
            var totalPrice = bookingLineItem.Price * quantity;
            return totalPrice;
        }
    }
}
