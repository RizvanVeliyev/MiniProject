using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pustok.BLL.ViewModels.CategoryViewModels
{
    public class CategoryCreateViewModel:IViewModel
    {
        public string? Name { get; set; }
        public int? ParentId { get; set; }
        public List<SelectListItem>? ParentCategories { get; set; }=new List<SelectListItem>();


    }
}
