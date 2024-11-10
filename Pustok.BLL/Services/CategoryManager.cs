using AutoMapper;
using Pustok.BLL.Constants;
using Pustok.BLL.Extensions;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.BasketItemViewModels;
using Pustok.BLL.ViewModels.CategoryViewModels;
using Pustok.Core.Entities;
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
        public CategoryManager(IRepository<Category> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override async Task<CategoryViewModel> CreateAsync(CategoryCreateViewModel createViewModel)
        {
            if (!createViewModel.ImageFile.IsImage()) throw new Exception("not an image");
            if (!createViewModel.ImageFile.AllowedSize(2)) throw new Exception("not allowed size");
            var imageName = await createViewModel.ImageFile.GenerateFile(FilePathConstants.CategoryImagePath);
            createViewModel.ImageUrl = imageName;
            return await base.CreateAsync(createViewModel);
        }
    }
}
