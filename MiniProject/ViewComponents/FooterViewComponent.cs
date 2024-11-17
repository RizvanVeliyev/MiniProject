using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.UI.ViewModels;

namespace MiniProject.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public async Task<ViewViewComponentResult> InvokeAsync()
        {
            string FacebookLink = "http://Facebook.com";
            string InstagramLink = "http://Instagram.com";
            var footerViewModel = new FooterViewModel
            {
                FacebookLink = FacebookLink,
                InstagramLink = InstagramLink,

            };
            return View(footerViewModel);
        }
    }
}
