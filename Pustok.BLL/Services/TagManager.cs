using AutoMapper;
using Pustok.BLL.Exceptions;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.TagViewModels;
using Pustok.Core.Entities;
using Pustok.DAL.Repositories;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.BLL.Services
{
    public class TagManager : CrudManager<Tag, TagViewModel, TagCreateViewModel, TagUpdateViewModel>, ITagService
    {
        ITagRepository _tagRepository;
        IMapper _mapper;
        public TagManager(ITagRepository tagRepository, IMapper mapper) : base(tagRepository, mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        

        public async Task<TagUpdateViewModel> GetUpdatedTagAsync(int id)
        {
            var tag = await _tagRepository.GetAsync(id);

            if (tag is null)
                throw new NotFoundException($"{id}-this tag is not found");

            TagUpdateViewModel vm = new() { Name = "" };
            vm = _mapper.Map(tag, vm);

            return vm;
        }

        public override async Task<TagViewModel> DeleteAsync(int id)
        {
            var tag = await _tagRepository.GetAsync(id);

            if (tag is null)
                throw new NotFoundException($"{id}-this tag is not found");

            tag.IsDeleted = true;
            await _tagRepository.UpdateAsync(tag);

            var tagViewModel = _mapper.Map<TagViewModel>(tag);
            return tagViewModel;
        }


    }





}
