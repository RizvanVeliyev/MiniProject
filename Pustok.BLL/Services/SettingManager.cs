using AutoMapper;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.SettingViewModels;
using Pustok.Core.Entities;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.BLL.Services
{
    public class SettingManager : CrudManager<Setting, SettingViewModel, SettingCreateViewModel, SettingUpdateViewModel>, ISettingService
    {
        public SettingManager(IRepository<Setting> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }





}
