using AutoMapper;
using Pustok.BLL.Exceptions;
using Pustok.BLL.Extensions;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.SliderViewModels;
using Pustok.Core.Entities;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.BLL.Services
{
    public class SliderManager : CrudManager<Slider, SliderViewModel, SliderCreateViewModel, SliderUpdateViewModel>, ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IMapper _mapper;
        private readonly CloudinaryManager _cloudinaryManager;
        public SliderManager(ISliderRepository sliderRepository, IMapper mapper,CloudinaryManager cloudinaryManager) : base(sliderRepository, mapper)
        {
            _mapper = mapper;
            _sliderRepository = sliderRepository;
            _cloudinaryManager = cloudinaryManager;
        }

        
        

        public override async Task<SliderViewModel> CreateAsync(SliderCreateViewModel createViewModel)
        {
            if (!createViewModel.ImageFile.IsImage())
            {
                throw new Exception("Not an Image");
            }
            if (!createViewModel.ImageFile.AllowedSize(2))
            {
                throw new Exception("Invalid image size");
            }

            //var imageName = await createViewModel.ImageFile.GenerateFile(FilePathConstants.CategoryImagePath);

            var imageName = await _cloudinaryManager.FileCreateAsync(createViewModel.ImageFile);
            createViewModel.ImageUrl = imageName;

            return await base.CreateAsync(createViewModel);
        }

        public override async Task<SliderViewModel> DeleteAsync(int id)
        {
            var slider = await _sliderRepository.GetAsync(id);

            if (slider is null)
                throw new NotFoundException("This category is not found");

            slider.isDeleted = true;

            await _sliderRepository.UpdateAsync(slider);

            var vm = _mapper.Map<SliderViewModel>(slider);

            return vm;
        }

        public async Task<SliderUpdateViewModel> GetUpdatedSliderAsync(int id)
        {
            var slider = await _sliderRepository.GetAsync(id);

            if (slider is null)
                throw new NotFoundException($"{id}-this category is not found");

            //SliderUpdateViewModel vm = new() { Title = "" ,Description="",Price=0,ImageUrl=""};
            //vm = _mapper.Map(slider, vm);
            SliderUpdateViewModel vm = _mapper.Map<SliderUpdateViewModel>(slider);


            return vm;
        }

        public override async Task<SliderViewModel> UpdateAsync(SliderUpdateViewModel updateViewModel)
        {
            if (!updateViewModel.ImageFile?.IsImage() ?? false)
            {
                throw new InvalidInputException("Invalid input");
            }
            if (!updateViewModel.ImageFile?.AllowedSize(2) ?? false)
            {
                throw new Exception("Invalid image size");
            }


            var existSlider = await _sliderRepository.GetAsync(x => x.Id == updateViewModel.Id, IsTracking: false);

            if (existSlider is null)
                throw new InvalidInputException("invalid input");

            if (updateViewModel.ImageFile != null)
            {
                var imageName = await _cloudinaryManager.FileCreateAsync(updateViewModel.ImageFile);
                await _cloudinaryManager.FileDeleteAsync(existSlider.ImageUrl);
                updateViewModel.ImageUrl = imageName;
            }


            return await base.UpdateAsync(updateViewModel);
        }
    }





}
