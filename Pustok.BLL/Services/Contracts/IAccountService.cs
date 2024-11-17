using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pustok.BLL.ViewModels.AppUserViewModels;

namespace Pustok.BLL.Services.Contracts
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(RegisterViewModel vm, ModelStateDictionary modelState);
        Task<bool> LoginAsync(LoginViewModel vm, ModelStateDictionary modelState);
        Task<bool> SignOutAsync();
        Task<List<UserViewModel>> GetAllUsersAsync();
        Task<bool> ChangeUserRoleAsync(ChangeRoleViewModel model, ModelStateDictionary modelState);
        Task<ChangeRoleViewModel> GetChangeRoleModelAsync(string userId);


    }
}
