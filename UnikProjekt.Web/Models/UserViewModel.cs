using System.ComponentModel.DataAnnotations;

namespace UnikProjekt.Web.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Fornavn")]
        public string FirstName { get; set; }

        [Display(Name = "Efternavn")]
        public string LastName { get; set; }
        public string Email { get; set; }

        [Display(Name = "Mobil")]
        public string MobileNumber { get; set; }

        [Display(Name = "Adresse")]
        public string FullAddress
        {
            get
            {
                return $"{Street} {StreetNumber}, {PostCode} {City}";
            }
        }
        [Display(Name = "Vejnavn")]
        public string Street { get; set; }

        [Display(Name = "Vej nummer")]
        public string StreetNumber { get; set; }

        [Display(Name = "Postnummer")]
        public string PostCode { get; set; }

        [Display(Name = "By")]
        public string City { get; set; }

        [Display(Name = "Brugerroller")]
        public List<string> UserRoles { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
