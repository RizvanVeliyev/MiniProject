using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.ProductViewModels;
using Pustok.DAL.DataContexts;

namespace MiniProject.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin,Moderator")]

    public class ProductsController : AdminController
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string FOLDER_PATH = "";
        private readonly IProductService _productService;

        public ProductsController(AppDbContext context, IWebHostEnvironment webHostEnvironment,IProductService productService)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _productService = productService;

            FOLDER_PATH = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "images");
        }

        public async Task<IActionResult> Index()
        {
            var products = (await _productService.GetAllAsync(predicate: p => !p.IsDeleted, include: p => p.Include(p => p.ProductImages))).ToList();


            return View(products);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _productService.CreateAsync(vm);

            return RedirectToAction("Index");
        }
    }
}
