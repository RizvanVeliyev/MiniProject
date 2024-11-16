using AutoMapper;
using Pustok.BLL.Exceptions;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.BasketItemViewModels;
using Pustok.BLL.ViewModels.TagViewModels;
using Pustok.Core.Entities;
using Pustok.DAL.Repositories;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.BLL.Services
{
    public class BasketItemManager : CrudManager<BasketItem, BasketItemViewModel, BasketItemCreateViewModel, BasketItemUpdateViewModel>, IBasketItemService
    {
        IBasketItemRepository _basketItemRepository;
        IMapper _mapper;
        public BasketItemManager(IBasketItemRepository basketItemRepository, IMapper mapper) : base(basketItemRepository, mapper)
        {
            _basketItemRepository = basketItemRepository;
            _mapper = mapper;
        }

        public async Task<BasketItemUpdateViewModel> GetUpdatedBasketItemAsync(int id)
        {
            var basketItem = await _basketItemRepository.GetAsync(id);

            if (basketItem is null)
                throw new NotFoundException($"{id}-this tag is not found");

            BasketItemUpdateViewModel vm = _mapper.Map<BasketItemUpdateViewModel>(basketItem);

            return vm;
        }

        public override async Task<BasketItemViewModel> DeleteAsync(int id)
        {
            var basketItem = await _basketItemRepository.GetAsync(id);

            if (basketItem is null)
                throw new NotFoundException($"{id}-this tag is not found");

            basketItem.IsDeleted = true;
            await _basketItemRepository.UpdateAsync(basketItem);

            var basketItemViewModel = _mapper.Map<BasketItemViewModel>(basketItem);
            return basketItemViewModel;
        }
    }
}
