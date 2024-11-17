using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.AppUserViewModels;
using Pustok.Core.Entities;

namespace MiniProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(IAccountService service, UserManager<AppUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            var result = await _service.RegisterAsync(vm, ModelState);

            if (result == false)
                return View(vm);

            return Json("Ok");
        }


        public async Task<IActionResult> Index()
        {
            var users=await _service.GetAllUsersAsync();
            return View(users);
        }

       

        public async Task<IActionResult> ChangeRole(string userId)
        {
            var model = await _service.GetChangeRoleModelAsync(userId);
            if (model == null)
                throw new Exception("User not found");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRole(ChangeRoleViewModel model)
        {
            var result = await _service.ChangeUserRoleAsync(model, ModelState);
            if (!result)
            {
                ModelState.AddModelError("", "Error updating user roles.");
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ToggleActivationAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            
            user.IsActive = !user.IsActive;
            var result = await _userManager.UpdateAsync(user); 
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            var result = await _service.LoginAsync(vm, ModelState);

            if (result == false) return View(vm);

            return Json("ok");
        }


        public async Task<IActionResult> LogOut()
        {
            var result = await _service.SignOutAsync();


            if (result is false)
                return BadRequest();

            return Json("OK");

        }
    }
}
