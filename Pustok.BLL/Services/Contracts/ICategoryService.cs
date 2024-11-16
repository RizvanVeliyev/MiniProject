using Pustok.BLL.ViewModels.CategoryViewModels;
using Pustok.BLL.ViewModels.TagViewModels;
using Pustok.Core.Entities;

namespace Pustok.BLL.Services.Contracts
{
    public interface ICategoryService : ICrudService<Category, CategoryViewModel, CategoryCreateViewModel, CategoryUpdateViewModel>
    {
        Task<CategoryUpdateViewModel> GetUpdatedCategoryAsync(int id);
    }
}
