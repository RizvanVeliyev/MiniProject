using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.BasketItemViewModels;
using Pustok.Core.Entities;
using Pustok.DAL.DataContexts;
using System.Security.Claims;
using Pustok.BLL.UI.Services.Contracts;

namespace MiniProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHomeService _homeService;
        private readonly IProductService _productService;
        private readonly IBasketItemService _basketItemService;
        private readonly AppDbContext _context;
        private const string BASKET_KEY = "PUSTOK_BASKET_KEY";
        public HomeController(IHomeService homeService, IProductService productService, AppDbContext context, IBasketItemService basketItemService)
        {
            _homeService = homeService;
            _productService = productService;
            _context = context;
            _basketItemService = basketItemService;
        }

        public async Task<IActionResult> Index()
        {
            var homeViewModel = await _homeService.GetHomeViewModelAsync();

            return View(homeViewModel);


        }

        public async Task<IActionResult> AddToBasket(int id, string? returnUrl)
        {
            var product = await _productService.GetAsync(id);

            if (product is null)
                return NotFound();

            if (!User.Identity?.IsAuthenticated ?? true)
            {
                List<BasketItemViewModel> basket = _getBasketFromCookie();

                var existItem = await _basketItemService.GetAsync(predicate:b=>b.ProductId==id);

                if (existItem is { })
                    existItem.Count++;
                else
                {
                    BasketItemViewModel newItem = new()
                    {
                        ProductId = id,
                        Count = 1
                    };

                    basket.Add(newItem);
                }
                _appendBasketInCookie(basket);
            }
            else
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);



                if (userId is null)
                    return BadRequest();

                var existItem= await _basketItemService.GetAsync(predicate: b=>b.ProductId==product.Id && b.AppUserId==userId);

                if (existItem is not null)
                {
                    existItem.Count++;
                    _context.Update(existItem);
                    await _context.SaveChangesAsync();

                    if (returnUrl is not null)
                        return Redirect(returnUrl);

                    return RedirectToAction(nameof(Index));
                }

                BasketItem basketItem = new()
                {
                    AppUserId = userId,
                    ProductId = product.Id,
                    Count = 1
                };

                await _context.BasketItems.AddAsync(basketItem);
                await _context.SaveChangesAsync();


            }
            if (returnUrl is not null)
                return Redirect(returnUrl);

            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Decrease(int id, string? returnUrl)
        {
            var product = await _productService.GetAsync(id);

            if (product is null)
                return NotFound();

            if (!User.Identity?.IsAuthenticated ?? true)
            {

                List<BasketItemViewModel> basket = _getBasketFromCookie();

                var existItem = basket.FirstOrDefault(x => x.ProductId == id);

                if (existItem is { })
                    existItem.Count--;
                else
                {
                    return NotFound();
                }


                _appendBasketInCookie(basket);
            }
            else
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId is null)
                    return BadRequest();

                var existItem = await _basketItemService.GetAsync(predicate: b => b.ProductId == product.Id && b.AppUserId == userId);

                if (existItem is null)
                    return NotFound();

                existItem.Count--;
                _context.Update(existItem);
                await _context.SaveChangesAsync();

            }

            if (returnUrl is not null)
                return Redirect(returnUrl);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShoppingCard()
        {
            List<BasketGetViewModel> basket = new();

            if (User.Identity?.IsAuthenticated ?? false)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId is null)
                    return BadRequest();

                var basketItemList=(await _basketItemService.GetAllAsync(include:b=>b.Include(b=>b.Product).ThenInclude(b=>b.ProductImages), predicate: b => b.AppUserId == userId)).ToList();

                foreach (var basketItem in basketItemList)
                {
                    BasketGetViewModel vm = new()
                    {
                        Id = basketItem.Id,
                        Count = basketItem.Count,
                        Price = basketItem.Product.Price,
                        ImagePath = basketItem.Product.ProductImages?.FirstOrDefault()?.Path ?? "",
                        Name = basketItem.Product.Name,
                        ProductId = basketItem.ProductId,
                    };

                    basket.Add(vm);
                }


                return View(basket);

            }


            List<BasketItemViewModel> basketItems = _getBasketFromCookie();

            foreach (var basketIem in basketItems)
            {

                var product = await _productService.GetAsync(basketIem.ProductId);

                if (product is null)
                    continue;

                BasketGetViewModel vm = new()
                {
                    Count = basketIem.Count,
                    Price = product.Price,
                    ImagePath = product.ProductImages?.FirstOrDefault()?.ImageUrl ?? "",
                    Name = product.Name,
                    ProductId = product.Id
                };

                basket.Add(vm);
            }


            return View(basket);
        }


        private void _appendBasketInCookie(List<BasketItemViewModel> basket)
        {
            var newJson = JsonConvert.SerializeObject(basket);

            Response.Cookies.Append(BASKET_KEY, newJson);
        }

        private List<BasketItemViewModel> _getBasketFromCookie()
        {
            string? json = Request.Cookies[BASKET_KEY];

            List<BasketItemViewModel> basket = new();

            if (!string.IsNullOrEmpty(json))
                basket = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(json!) ?? new();
            return basket;
        }

    }
}
