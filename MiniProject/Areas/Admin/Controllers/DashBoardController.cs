using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MiniProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Moderator")]

    public class DashBoardController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
