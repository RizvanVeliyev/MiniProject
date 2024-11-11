using AutoMapper;
using Pustok.BLL.Exceptions;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.SubscribeViewModels;
using Pustok.Core.Entities;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.BLL.Services
{
    public class SubscribeManager : CrudManager<Subscribe, SubscribeViewModel, SubscribeCreateViewModel, SubscribeUpdateViewModel>, ISubscribeService
    {
        ISubscribeRepository _subscribeRepository;
        IMapper _mapper;
        public SubscribeManager(ISubscribeRepository subscribeRepository, IMapper mapper) : base(subscribeRepository, mapper)
        {
            _subscribeRepository = subscribeRepository;
            _mapper = mapper;
        }



        public async Task<SubscribeUpdateViewModel> GetUpdatedSubscribeAsync(int id)
        {
            var subscribe = await _subscribeRepository.GetAsync(id);

            if (subscribe is null)
                throw new NotFoundException($"{id}-this subscribe is not found");

            SubscribeUpdateViewModel vm = new() { Email = "" };
            vm = _mapper.Map(subscribe, vm);

            return vm;
        }

        public override async Task<SubscribeViewModel> DeleteAsync(int id)
        {
            var subscribe = await _subscribeRepository.GetAsync(id);

            if (subscribe is null)
                throw new NotFoundException($"{id}-this subscribe is not found");

            subscribe.isDeleted = true;
            await _subscribeRepository.UpdateAsync(subscribe);

            var subscribeViewModel = _mapper.Map<SubscribeViewModel>(subscribe);
            return subscribeViewModel;
        }
    }





}
