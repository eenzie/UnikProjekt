using System.ComponentModel.DataAnnotations;

namespace UnikProjekt.Web.Models;

public class EmailViewModel
{
    [Display(Name = "Modtager")]
    public string RecipientEmail { get; set; }
    [Display(Name = "Emne")]
    public string Subject { get; set; }
    [Display(Name = "Besked")]
    public string Message { get; set; }
}
