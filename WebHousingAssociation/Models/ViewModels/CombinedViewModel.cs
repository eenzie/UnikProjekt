namespace WebHousingAssociation.Models.ViewModels
{
    public class CombinedViewModel
    {
        public BasePageViewModel BasePageViewModel { get; set; } = new BasePageViewModel();
        public ThemeViewModel ThemeViewModel { get; set; } = new ThemeViewModel();

        public LoginViewModel LoginViewModel { get; set; }
        public string WebsiteTitle { get; set; }

    }
}
