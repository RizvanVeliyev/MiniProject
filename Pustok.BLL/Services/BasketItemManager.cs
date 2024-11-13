using AutoMapper;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.BasketItemViewModels;
using Pustok.Core.Entities;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.BLL.Services
{
    public class BasketItemManager : CrudManager<BasketItem, BasketItemViewModel, BasketItemCreateViewModel, BasketItemUpdateViewModel>, IBasketItemService
    {
        public BasketItemManager(IRepository<BasketItem> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
