namespace UnikProjekt.Web.Models.DTOs
{
    public class EditBookingItemDto
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public decimal Deposit { get; set; }
        public TimeOnly IntervalStart { get; set; }
        public TimeOnly IntervalEnd { get; set; }
        public int BookingTimeInMinutes { get; set; }
        public byte[] RowVersion { get; set; }

    }
}
