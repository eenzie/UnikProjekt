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
    public class BookingItem : Entity
    {
        internal BookingItem() { }

        public BookingItem(Guid id, string serviceName, decimal price, decimal deposit, TimeOnly intervalStart, TimeOnly intervalEnd, int maximumBookingTimeInMinutes)
        {
            //TODO: Create a validity checker for interval times (can't end before it starts)
            // Pre-conditions
            
            ServiceName = serviceName;
            Price = price;
            Deposit = deposit;
            IntervalStart = intervalStart;
            IntervalEnd = intervalEnd;
            BookingTimeInMinutes = maximumBookingTimeInMinutes;

            // Logic

            var timeSlots = CalculateTimeSlots(IntervalStart, IntervalEnd, BookingTimeInMinutes);

            // Post-conditions

            TimeSlots = timeSlots;
        }

        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public decimal? Deposit { get; set; }
        public TimeOnly IntervalStart { get; set; }
        public TimeOnly IntervalEnd { get; set; }
        public int BookingTimeInMinutes { get; set; }
        public int TimeSlots { get; set; }

        public static BookingItem Create(string serviceName, decimal price, decimal deposit, TimeOnly intervalStart, TimeOnly intervalEnd, int maximumBookingTimeInMinutes)
        {
            if (serviceName == null) throw new ArgumentNullException(nameof(serviceName));
            if (price == null) throw new ArgumentNullException(nameof(price));
            if (deposit == null) throw new ArgumentNullException(nameof(deposit));
            if (maximumBookingTimeInMinutes == null) throw new ArgumentNullException(nameof(maximumBookingTimeInMinutes));
            
            var bookingItem = new BookingItem(Guid.NewGuid(), serviceName, price, deposit, intervalStart, intervalEnd, maximumBookingTimeInMinutes);

            return bookingItem;
        }

        public void Update(string serviceName, decimal price, decimal deposit, TimeOnly intervalStart, TimeOnly intervalEnd, int maximumBookingTimeInMinutes)
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
            this.BookingTimeInMinutes = maximumBookingTimeInMinutes;

            this.TimeSlots = CalculateTimeSlots(IntervalStart, IntervalEnd, BookingTimeInMinutes);
        }

        private int CalculateTimeSlots(TimeOnly intervalStart, TimeOnly intervalEnd, int maximumBookingTimeInMinutes)
        {
            //TODO: Implement timeslot logic
            return 1;
        }

        private bool ValidateIntervals(TimeOnly intervalStart, TimeOnly intervalEnd) 
        {
            if (intervalStart > intervalEnd)
            {
                return false;
            }
            return true;
        }
    }

}
