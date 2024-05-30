using System.ComponentModel.DataAnnotations;

namespace UnikProjekt.Web.Models
{
    public class DocumentViewModel
    {
        [Required(ErrorMessage = "Bruger ID er påkrævet")]
        public Guid UserId { get; set; }

        [Display(Name = "Dokument indhold")]
        public IFormFile DocumentContent { get; set; } // IFormFile bruges til filupload i ASP.NET Core

        [Required]
        [StringLength(100, ErrorMessage = "Title kan ikke være længere end 100 tegn.")]
        [Display(Name = "Dokument Titel")]
        public string DocumentTitle { get; set; }

        [Display(Name = "Oploadet af: ")]
        public string UserName { get; set; }

        [Display(Name = "Ændringsdato")]
        public DateTime DateModified { get; set; }
    }
}
