using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnikProjekt.Domain.Shared;
using UnikProjekt.Domain.Value;

namespace UnikProjekt.Domain.Entities
{
    public class BookingLineItem : Entity
    {
        internal BookingLineItem() { }

        public BookingLineItem(Guid id, string serviceName, decimal price, decimal deposit, DateTime intervalStart, DateTime intervalEnd, int maximumBookingTimeInMinutes)
        {
            //TODO: Create a validity checker for interval times (can't end before it starts)
            // Pre-conditions
            
            ServiceName = serviceName;
            Price = price;
            Deposit = deposit;
            IntervalStart = intervalStart;
            IntervalEnd = intervalEnd;
            MaximumBookingTimeInMinutes = maximumBookingTimeInMinutes;

            // Logic

            var timeSlots = CalculateTimeSlots(IntervalStart, IntervalEnd, MaximumBookingTimeInMinutes);

            // Post-conditions

            TimeSlots = timeSlots;
        }

        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public decimal Deposit { get; set; }
        public DateTime IntervalStart { get; set; }
        public DateTime IntervalEnd { get; set; }
        public int MaximumBookingTimeInMinutes { get; set; }
        public int TimeSlots { get; set; }

        public static BookingLineItem Create(string serviceName, decimal price, decimal deposit, DateTime intervalStart, DateTime intervalEnd, int maximumBookingTimeInMinutes)
        {
            if (serviceName == null) throw new ArgumentNullException(nameof(serviceName));
            if (price == null) throw new ArgumentNullException(nameof(price));
            if (deposit == null) throw new ArgumentNullException(nameof(deposit));
            if (maximumBookingTimeInMinutes == null) throw new ArgumentNullException(nameof(maximumBookingTimeInMinutes));

            var bookingLineItem = new BookingLineItem(Guid.NewGuid(), serviceName, price, deposit, intervalStart, intervalEnd, maximumBookingTimeInMinutes);

            return bookingLineItem;
        }

        public void Update(string serviceName, decimal price, decimal deposit, DateTime intervalStart, DateTime intervalEnd, int maximumBookingTimeInMinutes)
        {
            if (serviceName == null) throw new ArgumentNullException(nameof(serviceName));
            if (price == null) throw new ArgumentNullException(nameof(price));
            if (deposit == null) throw new ArgumentNullException(nameof(deposit));
            if (maximumBookingTimeInMinutes == null) throw new ArgumentNullException(nameof(maximumBookingTimeInMinutes));

            this.ServiceName = serviceName;
            this.Price = price;
            this.Deposit = deposit;
            this.IntervalStart = intervalStart;
            this.IntervalEnd = intervalEnd;
            this.MaximumBookingTimeInMinutes = maximumBookingTimeInMinutes;

            this.TimeSlots = CalculateTimeSlots(IntervalStart, IntervalEnd, MaximumBookingTimeInMinutes);
        }

        private int CalculateTimeSlots(DateTime intervalStart, DateTime intervalEnd, int maximumBookingTimeInMinutes)
        {
            //TODO: Implement timeslot logic
            return 1;
        }
    }

}
