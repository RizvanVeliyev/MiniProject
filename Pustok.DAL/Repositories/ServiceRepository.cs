using Pustok.Core.Entities;
using Pustok.DAL.DataContexts;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.DAL.Repositories
{
    public class ServiceRepository : EfCoreRepository<Service>, IServiceRepository
    {
        public ServiceRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
