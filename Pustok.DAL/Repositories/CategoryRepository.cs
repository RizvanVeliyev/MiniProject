using Pustok.Core.Entities;
using Pustok.DAL.DataContexts;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.DAL.Repositories
{
    public class CategoryRepository : EfCoreRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
