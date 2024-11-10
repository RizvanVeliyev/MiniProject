using Microsoft.AspNetCore.Mvc;

namespace MiniProject.Areas.Admin.Controllers
{
    public class DashBoardController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
