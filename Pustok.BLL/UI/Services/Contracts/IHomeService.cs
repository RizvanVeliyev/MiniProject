using Pustok.BLL.UI.ViewModels;

namespace Pustok.BLL.UI.Services.Contracts
{
    public interface IHomeService
    {
        Task<HomeViewModel> GetHomeViewModelAsync();
    }
}
