namespace UnikProjekt.Web.Models.DTOs
{
    public class CreateBookingDto
    {
        public Guid UserId { get; set; }
        public DateTime DateBooked { get; set; }
        public List<CreateBookingLineDto> Items { get; set; }
    }
}
