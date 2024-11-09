using Pustok.Core.Entities;
using Pustok.DAL.DataContexts;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.DAL.Repositories
{
    public class SettingRepository : EfCoreRepository<Setting>, ISettingRepository
    {
        public SettingRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
