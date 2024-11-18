using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Pustok.Core.Entities;
using Pustok.Core.Paging;
using Pustok.DAL.DataContexts;
using Pustok.DAL.Repositories.Contracts;
using System.Linq;
using System.Linq.Expressions;

namespace Pustok.DAL.Repositories
{
    public class EfCoreRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;

        public EfCoreRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            var entityEntry = await _appDbContext.Set<T>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public virtual async Task<T> DeleteAsync(T entity)
        {
            var entityEntry = _appDbContext.Set<T>().Remove(entity);
            await _appDbContext.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public virtual async Task<Paginate<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int index = 0, int size = 10, bool enableTracking = true)
        {
            IQueryable<T> query = _appDbContext.Set<T>();
            if (!enableTracking) 
                query = query.AsNoTracking();

            if (predicate != null)
                query = query.Where(predicate);
            if (include != null)
                query = include(query);
            if (orderBy != null)
                query = orderBy(query);

            var result = await query.ToListAsync();
            return await query.ToPaginateAsync(index, size);

        }

        public virtual async Task<T?> GetAsync(int id)
        {
            var query = Query();
            var result = await query.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool IsTracking = true)
        {
            var query = Query();

            if (predicate != null)
                query = query.Where(predicate);

            if (!IsTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (orderBy != null)
                query = orderBy(query);


            var result = await query.FirstOrDefaultAsync();
            return result;
        }

        public IQueryable<T> Query()
        {
            return _appDbContext.Set<T>();
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            var entityEntry = _appDbContext.Set<T>().Update(entity);
            await _appDbContext.SaveChangesAsync();
            return entityEntry.Entity;
        }
    }
}
