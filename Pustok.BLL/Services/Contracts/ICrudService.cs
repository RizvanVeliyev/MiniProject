using Microsoft.EntityFrameworkCore.Query;
using Pustok.BLL.ViewModels;
using Pustok.Core.Entities;
using Pustok.Core.Paging;
using System.Linq.Expressions;

namespace Pustok.BLL.Services.Contracts
{
     public interface ICrudService<TEntity,TViewModel,TCreateViewModel,TUpdateViewModel>
        where TEntity : BaseEntity
        where TViewModel:IViewModel
        where TCreateViewModel : IViewModel
        where TUpdateViewModel : IViewModel

    {
        Task<TViewModel?> GetAsync(int id);
        Task<TViewModel?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);
        Task<Paginate<TViewModel>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            int index = 0, int size = 10, bool enableTracking = true);
        Task<TViewModel> CreateAsync(TCreateViewModel createViewModel);
        Task<TViewModel> UpdateAsync(TUpdateViewModel updateViewModel);
        Task<TViewModel> DeleteAsync(int id);
    }
}
