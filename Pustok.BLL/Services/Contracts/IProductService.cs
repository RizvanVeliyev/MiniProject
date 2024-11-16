using Pustok.BLL.ViewModels.ProductImageViewModels;
using Pustok.BLL.ViewModels.ProductViewModels;
using Pustok.BLL.ViewModels.SliderViewModels;
using Pustok.Core.Entities;

namespace Pustok.BLL.Services.Contracts
{
    public interface IProductService:ICrudService<Product,ProductViewModel,ProductCreateViewModel,ProductUpdateViewModel>
    {
        Task<ProductUpdateViewModel> GetUpdatedProductAsync(int id);

    }
}
