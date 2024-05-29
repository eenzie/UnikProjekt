using System.ComponentModel.DataAnnotations;

namespace UnikProjekt.Web.Models
{
    public class CreateBookingViewModel
    {
        [Display(Name = "Bruger id")]
        public Guid UserId { get; set; }

        [Display(Name = "Booking dato")]
        public DateTime DateBooked { get; set; }

        [Display(Name = "Booking servicer")]
        public IEnumerable<BookingItemViewModel> BookingItems { get; set; }

        [Display(Name = "Vælg en booking service")]
        public Guid SelectedBookingItemId { get; set; }

        [Display(Name = "Booking start tidspunkt")]
        public DateTime BookingStart { get; set; }

        [Display(Name = "Booking slut tidspunkt")]
        public DateTime BookingEnd { get; set; }


    }
}
