using Pustok.Core.Entities;
using Pustok.DAL.DataContexts;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.DAL.Repositories
{
    public class BasketItemRepository : EfCoreRepository<BasketItem>, IBasketItemRepository
    {
        public BasketItemRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
