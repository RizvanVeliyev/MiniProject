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
        private readonly IEmailService _emailService;
        private readonly ISubscribeService _subscribeService;

        public ProductsController(AppDbContext context, IWebHostEnvironment webHostEnvironment,IProductService productService, IEmailService emailService,ISubscribeService subscribeService)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _productService = productService;

            FOLDER_PATH = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "images");
            _emailService = emailService;
            _subscribeService = subscribeService;
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

            string body = "yeni product yaratdig ay musteri!";

            var subscribes = await _subscribeService.GetAllAsync(predicate: s => s.isDeleted == false);

            foreach (var item in subscribes)
            {
                _emailService.SendEmail(item.Email!, "Salam", body);

            }


            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var vm = await _productService.GetUpdatedProductAsync(id);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _productService.UpdateAsync(model);

            return RedirectToAction(nameof(Index));

        }
    }
}
