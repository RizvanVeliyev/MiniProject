using AutoMapper;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.CategoryViewModels;
using Pustok.BLL.ViewModels.ProductImageViewModels;
using Pustok.Core.Entities;
using Pustok.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.BLL.Services
{
    public class ProductImageManager : CrudManager<ProductImage, ProductImageViewModel, ProductImageCreateViewModel, ProductImageUpdateViewModel>, IProductImageService
    {
        public ProductImageManager(IRepository<ProductImage> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }

}
