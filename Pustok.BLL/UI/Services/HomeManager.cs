using Microsoft.EntityFrameworkCore;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.UI.Services.Contracts;
using Pustok.BLL.UI.ViewModels;

namespace Pustok.BLL.UI.Services
{
    public class HomeManager : IHomeService
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public HomeManager(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<HomeViewModel> GetHomeViewModelAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            //var products = await _productService.GetAllAsync(include: x => x.Include(y => y.ProductImages!).Include(c => c.ProductCategories)!.ThenInclude(t => t.Category)!);
            var products = (await _productService.GetAllAsync(predicate: p => !p.IsDeleted, include: p => p.Include(p => p.ProductImages))).ToList();

            var model = new HomeViewModel
            {
                Categories = categories,
                Products = products
            };

            return model;
        }
    }
}
