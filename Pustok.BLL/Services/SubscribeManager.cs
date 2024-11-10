using AutoMapper;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.SubscribeViewModels;
using Pustok.Core.Entities;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.BLL.Services
{
    public class SubscribeManager : CrudManager<Subscribe, SubscribeViewModel, SubscribeCreateViewModel, SubscribeUpdateViewModel>, ISubscribeService
    {
        public SubscribeManager(IRepository<Subscribe> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }





}
