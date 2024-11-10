using Pustok.BLL.ViewModels.SettingViewModels;
using Pustok.BLL.ViewModels.TagViewModels;
using Pustok.Core.Entities;

namespace Pustok.BLL.Services.Contracts
{
    public interface ISettingService : ICrudService<Setting, SettingViewModel, SettingCreateViewModel, SettingUpdateViewModel>
    {
    }
}
