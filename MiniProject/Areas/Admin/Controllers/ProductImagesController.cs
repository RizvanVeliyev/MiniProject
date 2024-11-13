using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.ProductImageViewModels;
using Pustok.BLL.ViewModels.TagViewModels;

namespace MiniProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Moderator")]

    public class ProductImagesController : AdminController
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IActionResult>  Index()
        {
            var produtImages = (await _productImageService.GetAllAsync(predicate: pi => !pi.isDeleted, include: pi => pi.Include(p => p.Product))).ToList();

            return View(produtImages);
        }

        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(ProductImageCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _productImageService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
