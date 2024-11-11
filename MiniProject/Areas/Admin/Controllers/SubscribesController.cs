using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.SubscribeViewModels;

namespace MiniProject.Areas.Admin.Controllers
{
    public class SubscribesController : AdminController
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribesController(ISubscribeService SubscribeService)
        {
            _subscribeService = SubscribeService;
        }

        public async Task<IActionResult> Index()
        {
            var Subscribes = (await _subscribeService.GetAllAsync()).Where(t => !t.IsDeleted).ToList();

            return View(Subscribes);
        }

        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(SubscribeCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _subscribeService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var Subscribe = await _subscribeService.GetAsync(id);
            return View(Subscribe);

        }

        public async Task<IActionResult> Update(int id)
        {
            var vm = await _subscribeService.GetUpdatedSubscribeAsync(id);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SubscribeUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _subscribeService.UpdateAsync(model);

            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int id)
        {
            await _subscribeService.DeleteAsync(id);



            return RedirectToAction(nameof(Index));
        }
    }
}
