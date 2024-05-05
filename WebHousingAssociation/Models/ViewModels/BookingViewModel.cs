namespace WebHousingAssociation.Models.ViewModels
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Quantity { get; set; }
        //public string BookingComment { get; set; }
    }
}
