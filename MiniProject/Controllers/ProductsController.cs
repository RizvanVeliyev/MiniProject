using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Pustok.BLL.ViewModels.ProductViewModels;
using Pustok.BLL.UI.ViewModels;


namespace MiniProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

       
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetAsync(predicate:p=>p.Id==id,include: p => p.Include(p=>p.ProductTags!).ThenInclude(p=>p.Tag));
            if(product == null ) return NotFound();
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
           
           
            var products = await _productService.GetAllAsync(p => p.IsDeleted == false && p.Name.Contains(query));

            var homeViewModel = new HomeViewModel
            {
                Products = products
            };

            return PartialView("_SearchResults", homeViewModel);
        }
    }
}
