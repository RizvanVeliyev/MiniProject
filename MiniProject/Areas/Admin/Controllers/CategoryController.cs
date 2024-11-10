using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.CategoryViewModels;

namespace MiniProject.Areas.Admin.Controllers
{
    public class CategoryController : AdminController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categoryList = await _categoryService.GetAllAsync();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            await _categoryService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
