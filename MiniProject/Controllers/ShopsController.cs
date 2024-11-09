using Microsoft.AspNetCore.Mvc;

namespace MiniProject.Controllers
{
    public class ShopsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }
    }
}
