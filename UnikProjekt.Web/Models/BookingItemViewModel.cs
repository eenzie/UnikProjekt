using System.ComponentModel.DataAnnotations;

namespace UnikProjekt.Web.Models
{
    public class BookingItemViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Service Navn")]
        public string ServiceName { get; set; }
        [Display(Name = "Pris")]
        public decimal Price { get; set; }
        [Display(Name = "Depositum")]
        public decimal Deposit { get; set; }

        [Display(Name = "Interval start")]
        public TimeOnly IntervalStart { get; set; }

        [Display(Name = "Interval slut")]
        public TimeOnly IntervalEnd { get; set; }

        [Display(Name = "Booking tid i minutter")]
        public int BookingTimeInMinutes { get; set; }

        public byte[] RowVersion { get; set; }
    }
}

