using Pustok.BLL.ViewModels.SliderViewModels;
using Pustok.BLL.ViewModels.TagViewModels;
using Pustok.Core.Entities;

namespace Pustok.BLL.Services.Contracts
{
    public interface ISliderService : ICrudService<Slider, SliderViewModel, SliderCreateViewModel, SliderUpdateViewModel>
    {
        Task<SliderUpdateViewModel> GetUpdatedSliderAsync(int id);

    }
}
