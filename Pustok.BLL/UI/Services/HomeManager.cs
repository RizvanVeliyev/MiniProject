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
        private readonly ISliderService _sliderService;
        private readonly IServiceService _serviceService;

        public HomeManager(IProductService productService, ICategoryService categoryService,ISliderService sliderService, IServiceService serviceService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _sliderService = sliderService;
            _serviceService = serviceService;
        }

        public async Task<HomeViewModel> GetHomeViewModelAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            //var products = await _productService.GetAllAsync(include: x => x.Include(y => y.ProductImages!).Include(c => c.ProductCategories)!.ThenInclude(t => t.Category)!);
            var products = (await _productService.GetAllAsync(predicate: p => !p.IsDeleted, include: p => p.Include(p => p.ProductImages))).ToList();
            var sliders = await _sliderService.GetAllAsync(predicate: p => !p.isDeleted);
            var services = await _serviceService.GetAllAsync(predicate: p => !p.IsDeleted);

            var model = new HomeViewModel
            {
                Sliders=sliders,
                Categories = categories,
                Products = products,
                Services= services
            };

            return model;
            
        }
    }
}
