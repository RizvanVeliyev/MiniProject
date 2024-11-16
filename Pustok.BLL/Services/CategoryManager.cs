using AutoMapper;
using Pustok.BLL.Constants;
using Pustok.BLL.Exceptions;
using Pustok.BLL.Extensions;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.BasketItemViewModels;
using Pustok.BLL.ViewModels.CategoryViewModels;
using Pustok.BLL.ViewModels.TagViewModels;
using Pustok.Core.Entities;
using Pustok.DAL.Repositories;
using Pustok.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.BLL.Services
{
    public class CategoryManager : CrudManager<Category, CategoryViewModel, CategoryCreateViewModel, CategoryUpdateViewModel>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper) : base(categoryRepository, mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper= mapper;
        }


        //public override async Task<CategoryViewModel> CreateAsync(CategoryCreateViewModel createViewModel)
        //{
        //    if (!createViewModel.ImageFile.IsImage()) throw new Exception("not an image");
        //    if (!createViewModel.ImageFile.AllowedSize(2)) throw new Exception("not allowed size");
        //    var imageName = await createViewModel.ImageFile.GenerateFile(FilePathConstants.CategoryImagePath);
        //    createViewModel.ImageUrl = imageName;
        //    return await base.CreateAsync(createViewModel);
        //}

        public async Task<CategoryUpdateViewModel> GetUpdatedCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(id);

            if (category is null)
                throw new NotFoundException($"{id}-this tag is not found");

            CategoryUpdateViewModel vm = new() { Name = "" };
            vm = _mapper.Map(category, vm);

            return vm;
        }


        public override async Task<CategoryViewModel> DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(id);

            if (category is null)
                throw new NotFoundException($"{id}-this tag is not found");

            category.IsDeleted = true;
            await _categoryRepository.UpdateAsync(category);

            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
            return categoryViewModel;
        }
    }
}
