using Pustok.BLL.ViewModels.SubscribeViewModels;
using Pustok.Core.Entities;

namespace Pustok.BLL.Services.Contracts
{
    public interface ISubscribeService : ICrudService<Subscribe, SubscribeViewModel, SubscribeCreateViewModel, SubscribeUpdateViewModel>
    {
    }
}
