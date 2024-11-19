using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Pustok.BLL.ViewModels.ProductViewModels;
using Pustok.BLL.UI.ViewModels;
using Pustok.Core.Paging;
using AutoMapper;


namespace MiniProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

       
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetAsync(predicate:p=>p.Id==id,include: p => p.Include(p=>p.ProductTags!).ThenInclude(p=>p.Tag).Include(x=>x.ProductImages));
            if(product == null ) return NotFound();
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
           
           
            var products = await _productService.GetAllAsync(p => p.IsDeleted == false && p.Name.Contains(query), include: p => p.Include(p => p.ProductImages));

            var homeViewModel = new HomeViewModel
            {
                Products = products
            };

            return PartialView("_SearchResults", homeViewModel);
        }

        public async Task<IActionResult> ShopGrid(int pageIndex = 1, int pageSize = 3)
        {
            var products = await _productService.GetAllAsync(
                predicate: p => !p.IsDeleted,
                include: p => p.Include(p => p.ProductImages),
                index: pageIndex - 1,  // Səhifə sıfırdan başlayır
                size: pageSize
            );

            var totalCount = products.Count;

            var model = new Paginate<ProductViewModel>
            {
                Items = products.Items,
                Count = totalCount,
                Size = pageSize,
                Index = pageIndex - 1,
                Pages = (int)Math.Ceiling((double)totalCount / pageSize)
            };

            // Yalnız partial view qaytarılır
            return View("ShopGrid", model);
        }


        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            var products = await _productService.GetAllAsync(predicate: p => p.CategoryId == categoryId);

            return PartialView("_ProductListPartial", products);
        }

    }
}
