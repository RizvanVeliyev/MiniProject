using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pustok.BLL.ViewModels.CategoryViewModels
{
    public class CategoryUpdateViewModel:IViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<SelectListItem>? ParentCategories { get; set; } = new List<SelectListItem>();

        public int? ParentId { get; set; }
    }
}
