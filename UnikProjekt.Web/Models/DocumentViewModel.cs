using System.ComponentModel.DataAnnotations;

namespace UnikProjekt.Web.Models
{
    public class DocumentViewModel
    {
        [Required]
        [Display(Name = "Document indhold")]
        public IFormFile DocumentContent { get; set; } // IFormFile bruges til filupload i ASP.NET Core

        [Required]
        [StringLength(100, ErrorMessage = "Title kan ikke være længere end 100 tegn.")]
        [Display(Name = "Document Titel")]
        public string DocumentTitle { get; set; }

        [Display(Name = "Uploaded af: ")]
        public string UserName { get; set; }

        // Dato for sidste ændring
        [Display(Name = "Ændringsdato")]
        public DateTime DateModified { get; set; } = DateTime.Now;
    }
}
