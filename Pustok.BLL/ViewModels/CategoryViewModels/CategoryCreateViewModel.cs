using Microsoft.AspNetCore.Http;
using System.Web.Mvc;

namespace Pustok.BLL.ViewModels.CategoryViewModels
{
    public class CategoryCreateViewModel:IViewModel
    {
        public required string Name { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
        public int? ParentId { get; set; }
        public IEnumerable<SelectListItem>? ParentCategories { get; set; }


    }
}
