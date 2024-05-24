namespace UnikProjekt.Web.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        //public string Address { get; set; }

        public string FullAddress
        {
            get
            {
                return $"{Street} {StreetNumber}, {PostCode} {City}";
            }
        }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
    }
}
