using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.UI.Services.Contracts;
using Pustok.BLL.UI.ViewModels;
using Pustok.BLL.ViewModels.CategoryViewModels;
using Pustok.BLL.ViewModels.ProductViewModels;
using Pustok.BLL.ViewModels.ServiceViewModels;
using Pustok.BLL.ViewModels.SliderViewModels;
using Pustok.Core.Paging;

namespace Pustok.BLL.UI.Services
{
    public class HomeManager : IHomeService
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISliderService _sliderService;
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;

        public HomeManager(IProductService productService, ICategoryService categoryService,ISliderService sliderService, IServiceService serviceService,IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _sliderService = sliderService;
            _serviceService = serviceService;
            _mapper = mapper;
        }

        public async Task<HomeViewModel> GetHomeViewModelAsync()
        {
            var categories = await _categoryService.GetAllAsync(predicate: c => !c.IsDeleted);
            var products = await _productService.GetAllAsync(predicate: p => !p.IsDeleted, include: p => p.Include(p => p.ProductImages));
            var sliders = await _sliderService.GetAllAsync(predicate: p => !p.isDeleted);
            var services = await _serviceService.GetAllAsync(predicate: p => !p.IsDeleted);

            var model = new HomeViewModel
            {
                Categories = _mapper.Map<Paginate<CategoryViewModel>>(categories),
                Products = _mapper.Map<Paginate<ProductViewModel>>(products),
                Sliders = _mapper.Map<Paginate<SliderViewModel>>(sliders),
                Services = _mapper.Map<Paginate<ServiceViewModel>>(services),
            };

            return model;


            
        }
    }
}
