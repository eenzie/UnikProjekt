namespace UnikProjekt.Web.Models.DTOs
{
    public class CreateBookingLineDto
    {
        public Guid BookingItemId { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
    }
}
