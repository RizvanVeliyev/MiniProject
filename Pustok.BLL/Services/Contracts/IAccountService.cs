using Pustok.BLL.ViewModels.AppUserViewModels;
using System.Web.Mvc;

namespace Pustok.BLL.Services.Contracts
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(RegisterViewModel vm, ModelStateDictionary modelState);
        Task<bool> LoginAsync(LoginViewModel vm, ModelStateDictionary modelState);
        Task<bool> SignOutAsync();


    }
}
