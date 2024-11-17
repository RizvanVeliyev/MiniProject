using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.CategoryViewModels;

namespace MiniProject.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin,Moderator")]

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

        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync(predicate: c => c.ParentId == null);
            var model = new CategoryCreateViewModel
            {
                ParentCategories = categories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetAllAsync(predicate: c => c.ParentId == null);
                model.ParentCategories = categories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                    Selected = model.ParentId == c.Id
                }).ToList();
                return View(model);
            }
            await _categoryService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            var categories = await _categoryService.GetAllAsync(predicate: c => c.ParentId == null && c.Id != id);
            var model = new CategoryUpdateViewModel
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentId,
                ParentCategories = categories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                    Selected = category.ParentId == c.Id
                }).ToList()
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CategoryUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetAllAsync(predicate: c => c.ParentId == null && c.Id != model.Id); // Exclude the current category
                model.ParentCategories = categories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                    Selected = model.ParentId == c.Id
                }).ToList();

                return View(model);
            }

            var category = await _categoryService.GetUpdatedCategoryAsync(model.Id);
            if (category == null)
            {
                return NotFound();
            }

            category.Name = model.Name;
            category.ParentId = model.ParentId;

            await _categoryService.UpdateAsync(category);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryService.GetAsync(x => x.Id == id);
            return View(category);

        }




        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
