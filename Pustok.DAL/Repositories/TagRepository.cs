using Pustok.Core.Entities;
using Pustok.DAL.DataContexts;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.DAL.Repositories
{
    public class TagRepository : EfCoreRepository<Tag>, ITagRepository
    {
        public TagRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
