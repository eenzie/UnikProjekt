namespace UnikProjekt.Web.Models.DTOs
{
    public class EditUserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
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
        public List<string> UserRoles { get; set; }

        public byte[] RowVersion { get; set; }


    }
}
