using System.ComponentModel.DataAnnotations;
using UnikProjekt.Web.Models.DTOs;

namespace UnikProjekt.Web.Models
{
    public class BookingLineViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Booking service")]
        public BookingItemDto BookingItem { get; set; }

        [Display(Name = "Booking starttidspunkt")]
        public DateTime BookingStart { get; set; }

        [Display(Name = "Booking sluttidspunkt")]
        public DateTime BookingEnd { get; set; }
        [Display(Name = "Booking service pris")]
        public decimal ItemPrice { get; set; }
    }

}
