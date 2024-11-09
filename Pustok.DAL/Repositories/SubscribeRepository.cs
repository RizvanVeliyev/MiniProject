using Pustok.Core.Entities;
using Pustok.DAL.DataContexts;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.DAL.Repositories
{
    public class SubscribeRepository : EfCoreRepository<Subscribe>, ISubscribeRepository
    {
        public SubscribeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
