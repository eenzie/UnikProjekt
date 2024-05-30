namespace UnikProjekt.Web.Models.DTOs
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public UserDto User { get; set; }
        public DateTime DateBooked { get; set; }
        public List<BookingLineDto> Items { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalPrice { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
