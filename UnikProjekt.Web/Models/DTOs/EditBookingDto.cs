namespace UnikProjekt.Web.Models.DTOs
{
    public class EditBookingDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateBooked { get; set; }
        public List<EditBookingLineDto> Items { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
