using AutoMapper;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.ServiceViewModels;
using Pustok.Core.Entities;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.BLL.Services
{
    public class ServiceManager : CrudManager<Service, ServiceViewModel, ServiceCreateViewModel, ServiceUpdateViewModel>, IServiceService
    {
        public ServiceManager(IRepository<Service> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }





}
