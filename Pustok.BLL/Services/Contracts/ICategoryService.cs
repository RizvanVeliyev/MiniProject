using Pustok.BLL.ViewModels.CategoryViewModels;
using Pustok.Core.Entities;

namespace Pustok.BLL.Services.Contracts
{
    public interface ICategoryService : ICrudService<Category, CategoryViewModel, CategoryCreateViewModel, CategoryUpdateViewModel>
    {
    }
}
