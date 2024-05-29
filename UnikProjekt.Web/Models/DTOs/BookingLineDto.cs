namespace UnikProjekt.Web.Models.DTOs
{
    public class BookingLineDto
    {
        public Guid Id { get; set; }
        public BookingItemDto BookingItem { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public decimal ItemPrice { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
