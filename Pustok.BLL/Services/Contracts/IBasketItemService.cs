using Pustok.BLL.ViewModels.BasketItemViewModels;
using Pustok.Core.Entities;

namespace Pustok.BLL.Services.Contracts
{
    public interface IBasketItemService : ICrudService<BasketItem, BasketItemViewModel, BasketItemCreateViewModel, BasketItemUpdateViewModel>
    {
        Task<BasketItemUpdateViewModel> GetUpdatedBasketItemAsync(int id);
    }
}
