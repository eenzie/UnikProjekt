using Microsoft.AspNetCore.Identity;
using UnikProjekt.Web.Models.DTOs;

namespace UnikProjekt.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        //public Guid id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public List<UserRoleDto> UserRoles { get; set; } = new List<UserRoleDto>();
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
