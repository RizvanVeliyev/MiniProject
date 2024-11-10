using AutoMapper;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.ProductViewModels;
using Pustok.Core.Entities;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.BLL.Services
{
    public class ProductManager : CrudManager<Product, ProductViewModel, ProductCreateViewModel, ProductUpdateViewModel>, IProductService
    {
        public ProductManager(IRepository<Product> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }





}
