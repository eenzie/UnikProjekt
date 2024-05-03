using Microsoft.AspNetCore.Mvc;
using WebHousingAssociation.Services;

namespace WebHousingAssociation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ThemeService _themeService;
        private readonly AssociationInfoService _AssociationInfoService;

        public HomeController(ThemeService themeService, AssociationInfoService AssociationInfoService)
        {
            _themeService = themeService;
            _AssociationInfoService = AssociationInfoService;
        }

        public async Task<IActionResult> Index(string AssociationId)
        {
            var combinedViewModel = await _themeService.GetCombinedViewModel(AssociationId);
            string AssociationInfo = await _AssociationInfoService.GetAssociationInfo(AssociationId);
            //Putting CompanyInfo to the footer
            combinedViewModel.BasePageViewModel.FooterContent = AssociationInfo;
            return View("HomePage", combinedViewModel);
        }

        public async Task<IActionResult> Login(string associationId/*string userName, string password*/)
        {
            var combinedViewModel = await _themeService.GetCombinedViewModel(associationId);
            string associationInfo = await _AssociationInfoService.GetAssociationInfo(associationId);
            combinedViewModel.BasePageViewModel.FooterContent = associationInfo;
            return View(combinedViewModel);

        }
    }
}
