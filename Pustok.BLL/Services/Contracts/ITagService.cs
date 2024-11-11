using Pustok.BLL.ViewModels.TagViewModels;
using Pustok.Core.Entities;

namespace Pustok.BLL.Services.Contracts
{
    public interface ITagService : ICrudService<Tag,TagViewModel,TagCreateViewModel,TagUpdateViewModel>
    {
        Task<TagUpdateViewModel> GetUpdatedTagAsync(int id);
    }
}
