using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Pustok.BLL.Exceptions;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.AppUserViewModels;
using Pustok.Core.Entities;
using Pustok.DAL.Enums;

namespace Pustok.BLL.Services
{
    public class AccountManager : IAccountService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountManager(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<List<UserViewModel>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var userVm = _mapper.Map<List<UserViewModel>>(users);
            foreach (var viewModel in userVm)
            {
                var user = await _userManager.FindByNameAsync(viewModel.Username); if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user); viewModel.Roles = roles.ToList();
                }
            }
            return userVm;
        }



       



        public async Task<bool> ChangeUserRoleAsync(ChangeRoleViewModel model, ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) return false;
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) return false;
            var currentRoles = await _userManager.GetRolesAsync(user);
            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles); if (!removeResult.Succeeded)
                return false;
            var addResult = await _userManager.AddToRoleAsync(user, model.NewRole.ToString()); return addResult.Succeeded;
        }

        public async Task<ChangeRoleViewModel> GetChangeRoleModelAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return null;

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return null;

            var userRoles = await _userManager.GetRolesAsync(user);

            var viewModel = _mapper.Map<ChangeRoleViewModel>(user);

            viewModel.NewRole = (IdentityRoles)Enum.Parse(typeof(IdentityRoles), userRoles.FirstOrDefault());

            return viewModel;
        }



       

        public async Task<bool> LoginAsync(LoginViewModel vm, ModelStateDictionary modelState)
        {

            if (_httpContextAccessor.HttpContext.User.Identity?.IsAuthenticated ?? true)
                throw new InvalidInputException("User already signed");


            if (!modelState.IsValid)
                return false;
            var user = await _userManager.FindByEmailAsync(vm.EmailOrUserName);

            if (user is null)
                user = await _userManager.FindByNameAsync(vm.EmailOrUserName);

            if (user is null)
            {
                modelState.AddModelError("", "Email ve y apassword yanlisdir");
                return false;
            }

            var result = await _signInManager.PasswordSignInAsync(user, vm.Password, vm.SaveMe, true);
            if (!result.Succeeded)
            {
                modelState.AddModelError("", "Email ve y apassword yanlisdir");
                return false;
            }

            return true;

        }

        public async Task<bool> RegisterAsync(RegisterViewModel vm, ModelStateDictionary modelState)
        {
            if (_httpContextAccessor.HttpContext.User.Identity?.IsAuthenticated ?? true)
                throw new InvalidInputException("User already signed");


            if (!modelState.IsValid)
                return false;
            var user = _mapper.Map<AppUser>(vm);
            var result = await _userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded)
            {
                modelState.AddModelError("", string.Join(", ", result.Errors.Select(x => x.Description)));
                return false;
            }
            await _userManager.AddToRoleAsync(user, IdentityRoles.User.ToString());
            return true;

        }

        public async Task<bool> SignOutAsync()
        {
            if (!_httpContextAccessor.HttpContext.User.Identity?.IsAuthenticated ?? false)
                return false;

            await _signInManager.SignOutAsync();
            return true;
        }
    }
}
