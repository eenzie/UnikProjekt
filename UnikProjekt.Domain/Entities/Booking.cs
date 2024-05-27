using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnikProjekt.Domain.DomainService;
using UnikProjekt.Domain.Shared;
using UnikProjekt.Domain.Value;

namespace UnikProjekt.Domain.Entities
{
    public class Booking : Entity
    {
        internal Booking() : base(Guid.NewGuid()) 
        { 
        }

        internal Booking(Guid id, User user, DateTime dateBooked, List<BookingLine> items) : base(id)
        {
            // Pre-conditions
            
            User = user;
            DateBooked = dateBooked;
            Items = items;

            // Logic

            var subTotal = CalculateSubTotal(Items);
            var moms = 1.25M;
            var totalPrice = subTotal * moms;

            // Post-conditions

            SubTotal = subTotal;
            TotalPrice = totalPrice;
        }
        
        public User User { get; set; }
        public DateTime DateBooked { get; set; }
        public List<BookingLine> Items { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalPrice { get; set; }

        public static Booking Create(User user, DateTime dateBooked, List<BookingLine> items)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            //var domainService = services.GetService<IBookingDomainService>();

            var booking = new Booking(Guid.NewGuid(), user, dateBooked, items);
            
            return booking;
        }

        public void Update(User user, DateTime dateBooked, List<BookingLine> items, IServiceProvider services)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            var moms = 1.25M;

            this.User = user;
            this.DateBooked = dateBooked;
            this.Items = items;
            this.SubTotal = CalculateSubTotal(Items);
            this.TotalPrice = SubTotal * moms;
        }

        public void DeleteSelectedBookingItems(IEnumerable<Guid> bookingLineIds)
        {
            Items.RemoveAll(x => bookingLineIds.Contains(x.Id));
        }

        private decimal CalculateSubTotal(List<BookingLine> items)
        { 
            var subTotal = items.Sum(x => x.ItemPrice);
            return subTotal;
        }
    }
}
