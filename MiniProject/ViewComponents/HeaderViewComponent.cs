using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace MiniProject.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public async Task<ViewViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
