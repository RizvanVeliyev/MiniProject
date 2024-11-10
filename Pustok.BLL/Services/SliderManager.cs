using AutoMapper;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.SliderViewModels;
using Pustok.Core.Entities;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.BLL.Services
{
    public class SliderManager : CrudManager<Slider, SliderViewModel, SliderCreateViewModel, SliderUpdateViewModel>, ISliderService
    {
        public SliderManager(IRepository<Slider> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }





}
