using Pustok.Core.Entities;

namespace Pustok.DAL.Repositories.Contracts
{
    public interface IQuery<T> where T : BaseEntity
    {
        IQueryable<T> Query();
    }
}
