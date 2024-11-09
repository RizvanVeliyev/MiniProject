using Microsoft.EntityFrameworkCore.Query;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels;
using Pustok.Core.Entities;
using System.Linq.Expressions;

namespace Pustok.BLL.Services
{
    public class CrudManager<TEntity, TViewModel, TCreateViewModel, TUpdateViewModel> : ICrudService<TEntity, TViewModel, TCreateViewModel, TUpdateViewModel>
     where TEntity : BaseEntity
     where TViewModel : IViewModel
     where TCreateViewModel : IViewModel
     where TUpdateViewModel : IViewModel
    {
        public Task<TViewModel> CreateAsync(TCreateViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<TViewModel> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TViewModel>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            throw new NotImplementedException();
        }

        public Task<TViewModel?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TViewModel?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            throw new NotImplementedException();
        }

        public Task<TViewModel> UpdateAsync(TUpdateViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
