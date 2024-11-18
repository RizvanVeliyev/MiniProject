using Microsoft.EntityFrameworkCore.Query;
using Pustok.Core.Entities;
using Pustok.Core.Paging;
using System.Linq.Expressions;

namespace Pustok.DAL.Repositories.Contracts
{
    public interface IRepository<T> : IQuery<T> where T : BaseEntity
    {
        Task<T?> GetAsync(int id);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool IsTracking = true);
        Task<Paginate<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, int index = 0, int size = 10, bool enableTracking = true);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);

    }
}
