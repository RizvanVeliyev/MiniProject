using Pustok.BLL.ViewModels.SliderViewModels;
using Pustok.Core.Entities;

namespace Pustok.BLL.Services.Contracts
{
    public interface ISliderService : ICrudService<Slider, SliderViewModel, SliderCreateViewModel, SliderUpdateViewModel>
    {
    }
}
