using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.BasketItemViewModels;
using Pustok.Core.Entities;
using Pustok.DAL.DataContexts;
using System.Security.Claims;
using Pustok.BLL.UI.Services.Contracts;
using Pustok.BLL.ViewModels.SubscribeViewModels;
using Pustok.BLL.ViewModels.ContactViewModels;

namespace MiniProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHomeService _homeService;
        private readonly IProductService _productService;
        private readonly IBasketItemService _basketItemService;
        private readonly IEmailService _emailService;
        private readonly ISubscribeService _subscribeService;

        private readonly AppDbContext _context;
        private const string BASKET_KEY = "PUSTOK_BASKET_KEY";
        public HomeController(IHomeService homeService, IProductService productService, AppDbContext context, IBasketItemService basketItemService,IEmailService emailService,ISubscribeService subscribeService)
        {
            _homeService = homeService;
            _productService = productService;
            _context = context;
            _basketItemService = basketItemService;
            _emailService = emailService;
            _subscribeService = subscribeService;
        }

        public async Task<IActionResult> Index()
        {
            var homeViewModel = await _homeService.GetHomeViewModelAsync();

            return View(homeViewModel);


        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var body = $"Message: {model.Message}";

                _emailService.SendEmail(model.Email!, $"Message from{model.Name}", body);

                return View();
            }

            // If the model is not valid, re-render the form with validation errors
            return View(model);
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
            List<BasketItemViewModel> basket = new();

            if (User.Identity?.IsAuthenticated ?? false)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId is null)
                    return BadRequest();

                //var basketItemList=(await _basketItemService.GetAllAsync(include:b=>b.Include(b=>b.Product).ThenInclude(b=>b.ProductImages), predicate: b => b.AppUserId == userId)).ToList();
                var basketItemList = await _basketItemService.GetAllAsync(include: b => b.Include(b => b.Product).ThenInclude(b => b.ProductImages));

                foreach (var basketItem in basketItemList)
                {
                    BasketItemViewModel vm = new()
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

                BasketItemViewModel vm = new()
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

        public IActionResult SendEmail()
        {

            string body = "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Forgot Password</title>\r\n    <style>\r\n        body {\r\n            font-family: Arial, sans-serif;\r\n            background-color: #f4f4f4;\r\n            margin: 0;\r\n            padding: 0;\r\n        }\r\n        .email-container {\r\n            background-color: #ffffff;\r\n            max-width: 600px;\r\n            margin: 40px auto;\r\n            padding: 20px;\r\n            border-radius: 8px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }\r\n        .email-header {\r\n            text-align: center;\r\n            border-bottom: 1px solid #dddddd;\r\n            padding-bottom: 20px;\r\n            margin-bottom: 20px;\r\n        }\r\n        .email-header h1 {\r\n            color: #333333;\r\n        }\r\n        .email-body {\r\n            text-align: center;\r\n        }\r\n        .email-body p {\r\n            font-size: 16px;\r\n            color: #555555;\r\n        }\r\n        .email-body a {\r\n            display: inline-block;\r\n            margin-top: 20px;\r\n            padding: 10px 20px;\r\n            font-size: 16px;\r\n            background-color: #007BFF;\r\n            color: #ffffff;\r\n            text-decoration: none;\r\n            border-radius: 5px;\r\n        }\r\n        .email-footer {\r\n            margin-top: 30px;\r\n            font-size: 12px;\r\n            color: #888888;\r\n            text-align: center;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"email-container\">\r\n        <div class=\"email-header\">\r\n            <h1>Reset Your Password</h1>\r\n        </div>\r\n        <div class=\"email-body\">\r\n            <p>It looks like you requested to reset your password. Click the button below to create a new one:</p>\r\n            <a href=\"{{reset_link}}\">Reset Password</a>\r\n            <p>If you didn’t request this, please ignore this email.</p>\r\n        </div>\r\n        <div class=\"email-footer\">\r\n            <p>&copy; 2024 Your Company Name. All rights reserved.</p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>\r\n";

            _emailService.SendEmail("veliyevrizvan250@gmail.com", "Salam", body);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _subscribeService.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }

}

