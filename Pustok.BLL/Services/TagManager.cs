using AutoMapper;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.ViewModels.TagViewModels;
using Pustok.Core.Entities;
using Pustok.DAL.Repositories.Contracts;

namespace Pustok.BLL.Services
{
    public class TagManager : CrudManager<Tag, TagViewModel, TagCreateViewModel, TagUpdateViewModel>, ITagService
    {
        public TagManager(IRepository<Tag> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }





}
