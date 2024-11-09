using Pustok.Core.Entities;
using Pustok.DAL.DataContexts;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.DAL.Repositories
{
    public class ProductImageRepository : EfCoreRepository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
