using AutoMapper;
using Pustok.BLL.Exceptions;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.ServiceViewModels;
using Pustok.BLL.ViewModels.ServiceViewModels;
using Pustok.Core.Entities;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.BLL.Services
{
    public class ServiceManager : CrudManager<Service, ServiceViewModel, ServiceCreateViewModel, ServiceUpdateViewModel>, IServiceService
    {
        IServiceRepository _serviceRepository;
        IMapper _mapper;
        public ServiceManager(IServiceRepository serviceRepository, IMapper mapper) : base(serviceRepository, mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }



        public async Task<ServiceUpdateViewModel> GetUpdatedServiceAsync(int id)
        {
            var service = await _serviceRepository.GetAsync(id);

            if (service is null)
                throw new NotFoundException($"{id}-this service is not found");

            ServiceUpdateViewModel vm = new() { Title = "",Description="",IconUrl="" };
            vm = _mapper.Map(service, vm);

            return vm;
        }

        public override async Task<ServiceViewModel> DeleteAsync(int id)
        {
            var service = await _serviceRepository.GetAsync(id);

            if (service is null)
                throw new NotFoundException($"{id}-this service is not found");

            service.IsDeleted = true;
            await _serviceRepository.UpdateAsync(service);

            var serviceViewModel = _mapper.Map<ServiceViewModel>(service);
            return serviceViewModel;
        }
    }





}
