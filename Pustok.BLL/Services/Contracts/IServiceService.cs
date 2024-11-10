using Pustok.BLL.ViewModels.ServiceViewModels;
using Pustok.Core.Entities;

namespace Pustok.BLL.Services.Contracts
{
    public interface IServiceService : ICrudService<Service, ServiceViewModel, ServiceCreateViewModel, ServiceUpdateViewModel>
    {
    }
}
