using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels;
using Pustok.Core.Entities;
using Pustok.Core.Paging;
using Pustok.DAL.Repositories.Contracts;
using System.Linq.Expressions;

namespace Pustok.BLL.Services
{
    public class CrudManager<TEntity, TViewModel, TCreateViewModel, TUpdateViewModel> : ICrudService<TEntity, TViewModel, TCreateViewModel, TUpdateViewModel>
    where TEntity : BaseEntity
    where TViewModel : IViewModel
    where TCreateViewModel : IViewModel
    where TUpdateViewModel : IViewModel
    {

        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;


        public CrudManager(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<TViewModel> CreateAsync(TCreateViewModel createViewModel)
        {
            var entity = _mapper.Map<TEntity>(createViewModel);
            var result = await _repository.CreateAsync(entity);
            var createdEntityViewModel = _mapper.Map<TViewModel>(result);

            return createdEntityViewModel;

        }

        public virtual async Task<TViewModel> DeleteAsync(int id)
        {
            var deletedEntity = await _repository.GetAsync(id);
            if (deletedEntity == null) throw new Exception("Not Found");
            deletedEntity = await _repository.DeleteAsync(deletedEntity);
            var deletedEntityViewModel = _mapper.Map<TViewModel>(deletedEntity);
            return deletedEntityViewModel;

        }

        public virtual async Task<Paginate<TViewModel>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, 
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            int index = 0, int size = 10, bool enableTracking = true)
        {
            var entityList = await _repository.GetAllAsync(predicate, include, orderBy,index,size,enableTracking);
            var viewModels = _mapper.Map<Paginate<TViewModel>>(entityList);
            return viewModels;
        }

        public virtual async Task<TViewModel?> GetAsync(int id)
        {
            var entity = await _repository.GetAsync(id);
            var viewModel = _mapper.Map<TViewModel>(entity);
            return viewModel;
        }

        public virtual async Task<TViewModel?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            var entity = await _repository.GetAsync(predicate, include, orderBy);
            var viewModel = _mapper.Map<TViewModel>(entity);
            return viewModel;
        }

        public virtual async Task<TViewModel> UpdateAsync(TUpdateViewModel updateViewModel)
        {
            var entity = _mapper.Map<TEntity>(updateViewModel);
            var result = await _repository.UpdateAsync(entity);
            var updatedEntityViewModel = _mapper.Map<TViewModel>(result);
            return updatedEntityViewModel;
        }
    }
}
