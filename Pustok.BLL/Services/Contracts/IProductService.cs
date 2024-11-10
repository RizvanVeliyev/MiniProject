using Pustok.BLL.ViewModels.ProductImageViewModels;
using Pustok.BLL.ViewModels.ProductViewModels;
using Pustok.Core.Entities;

namespace Pustok.BLL.Services.Contracts
{
    public interface IProductService:ICrudService<Product,ProductViewModel,ProductCreateViewModel,ProductUpdateViewModel>
    {
    }
}
