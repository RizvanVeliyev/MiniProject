using Pustok.BLL.ViewModels.ProductImageViewModels;
using Pustok.Core.Entities;

namespace Pustok.BLL.Services.Contracts
{
    public interface IProductImageService : ICrudService<ProductImage, ProductImageViewModel, ProductImageCreateViewModel, ProductImageUpdateViewModel>
    {
    }
}
