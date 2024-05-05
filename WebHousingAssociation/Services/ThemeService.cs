using Newtonsoft.Json;
using WebHousingAssociation.Models;
using WebHousingAssociation.Models.ViewModels;

namespace WebHousingAssociation.Services
{
    public class ThemeService
    {
        private readonly TextService _textService;

        public ThemeService(TextService textService)
        {
            _textService = textService;
        }

        public async Task<CombinedViewModel> GetCombinedViewModel(string AssociationId)
        {

            // Opret stien til konfigurationsfilen relativt til rodstien for applikationen
            string configurationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "themeConfig.json");

            // Læs konfigurationsfilen
            string configJson = File.ReadAllText(configurationPath);

            // Deserialiser JSON til en liste af ThemeConfiguration-objekter
            List<ThemeConfiguration> themeConfigs = JsonConvert.DeserializeObject<List<ThemeConfiguration>>(configJson);

            // Find den rigtige ThemeConfiguration baseret på boligforenings-id
            ThemeConfiguration themeConfiguration = themeConfigs.FirstOrDefault(x => x.AssociationId == AssociationId);

            ThemeViewModel viewModel = new ThemeViewModel();
            if (themeConfiguration != null)
            {
                viewModel.ThemeColour = themeConfiguration.ThemeColour;
                viewModel.LogoPath = themeConfiguration.LogoPath;
                viewModel.Image = themeConfiguration.Image;
            }
            else
            {
                // Brug standardværdier, hvis themeConfiguration er null
                viewModel.ThemeColour = "#333333"; // Standard tema farve
                viewModel.LogoPath = "/Logo/Bolig.png"; // Standard sti til logo
                viewModel.Image = "/Images/FrontImage2.jpg";
            }

            // Hent data fra TextService
            string websiteTitle = _textService.GetWebsiteTitle();

            var combinedViewModel = new CombinedViewModel
            {
                ThemeViewModel = viewModel,
                WebsiteTitle = websiteTitle
            };

            return combinedViewModel;
        }
    }
}