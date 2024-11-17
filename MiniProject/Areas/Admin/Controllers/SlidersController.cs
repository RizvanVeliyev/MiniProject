using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.CategoryViewModels;
using Pustok.BLL.ViewModels.SliderViewModels;

namespace MiniProject.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin,Moderator")]

    public class SlidersController : AdminController
    {
        private readonly ISliderService _sliderService;

        public SlidersController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IActionResult> Index()
        {
            var sliderList = await _sliderService.GetAllAsync(predicate:s=>s.isDeleted==false);
            return View(sliderList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _sliderService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var vm = await _sliderService.GetUpdatedSliderAsync(id);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SliderUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _sliderService.UpdateAsync(model);

            return RedirectToAction(nameof(Index));

        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sliderService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
