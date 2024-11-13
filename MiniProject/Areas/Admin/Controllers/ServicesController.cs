using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.ServiceViewModels;

namespace MiniProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Moderator")]

    public class ServicesController : AdminController
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IActionResult> Index()
        {
            var serviceList = await _serviceService.GetAllAsync(predicate: s => !s.IsDeleted);
            return View(serviceList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _serviceService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var vm = await _serviceService.GetUpdatedServiceAsync(id);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ServiceUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _serviceService.UpdateAsync(model);

            return RedirectToAction(nameof(Index));

        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
