using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnikProjekt.Domain.Shared;
using UnikProjekt.Domain.Value;

namespace UnikProjekt.Domain.Entities
{
    public class Booking : Entity
    {
        internal Booking() { }

        public Booking(Guid id, User user, DateTime dateBooked, List<BookingLine> items, string bookingComment)
        {
            // Pre-conditions
            
            User = user;
            DateBooked = dateBooked;
            Items = items;
            BookingComment = bookingComment;

            // Logic

            var totalPrice = CalculateTotalPrice(Items);

            // Post-conditions

            TotalPrice = totalPrice;
        }

        public User User { get; set; }
        public DateTime DateBooked { get; set; }
        public List<BookingLine> Items { get; set; }
        public string BookingComment { get; set; }
        public decimal TotalPrice { get; set; }

        public static Booking Create(User user, DateTime dateBooked, List<BookingLine> items, string bookingComment)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (dateBooked == null) throw new ArgumentNullException(nameof(dateBooked));
            if (bookingComment == null) throw new ArgumentNullException(nameof(bookingComment));

            var booking = new Booking(Guid.NewGuid(), user, dateBooked, items, bookingComment);

            return booking;
        }

        public void Update(User user, DateTime dateBooked, List<BookingLine> items, string bookingComment)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (dateBooked == null) throw new ArgumentNullException(nameof(dateBooked));
            if (bookingComment == null) throw new ArgumentNullException(nameof(bookingComment));

            this.User = user;
            this.DateBooked = dateBooked;
            this.Items = items;
            this.BookingComment = bookingComment;
            this.TotalPrice = CalculateTotalPrice(Items);
        }

        private decimal CalculateTotalPrice(List<BookingLine> items)
        { 
            var totalPrice = items.Sum(x => x.TotalPrice);
            return totalPrice;
        }
    }
}
