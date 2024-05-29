using System.ComponentModel.DataAnnotations;
using UnikProjekt.Web.Models.DTOs;

namespace UnikProjekt.Web.Models
{
    public class BookingViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Bruger")]
        public UserDto User { get; set; }
        [Display(Name = "Booking dato")]
        public DateTime DateBooked { get; set; }
        [Display(Name = "Booking servicer")]
        public List<BookingLineViewModel> Items { get; set; }

        [Display(Name = "Subtotal")]
        public decimal SubTotal { get; set; }
        [Display(Name = "Total pris")]
        public decimal TotalPrice { get; set; }
        public byte[] RowVersion { get; set; }

    }
}



