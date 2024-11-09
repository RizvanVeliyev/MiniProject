namespace Pustok.BLL.ViewModels.CategoryViewModels
{
    public class CategoryCreateViewModel:IViewModel
    {
        public required string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int? ParentId { get; set; }
    }
}
