using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.BasketItemViewModels;

namespace MiniProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BasketItemController : Controller
    {
        private readonly IBasketItemService _basketItemService;

        public BasketItemController(IBasketItemService basketItemService)
        {
            _basketItemService = basketItemService;
        }

        // Index - Bütün basket itemləri göstərmək üçün
        public async Task<IActionResult> Index()
        {
            var basketItems = await _basketItemService.GetAllAsync(include: b => b.Include(b => b.Product).ThenInclude(p => p.ProductImages));
            return View(basketItems);
        }

        // Details - Basket item detalları
        public async Task<IActionResult> Details(int id)
        {
            var basketItem = await _basketItemService.GetAsync(
                predicate: b => b.Id == id,
                include: b => b.Include(b => b.Product).ThenInclude(p => p.ProductImages)
            );

            if (basketItem is null)
                return NotFound();

            return View(basketItem);
        }

        // Update - Basket item miqdarını dəyişmək
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var basketItem = await _basketItemService.GetUpdatedBasketItemAsync(id);

            return View(basketItem);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BasketItemUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var basketItem = await _basketItemService.GetUpdatedBasketItemAsync(model.Id);

            if (basketItem is null)
                return NotFound();

            basketItem.Count = model.Count;


            await _basketItemService.UpdateAsync(basketItem);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _basketItemService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
