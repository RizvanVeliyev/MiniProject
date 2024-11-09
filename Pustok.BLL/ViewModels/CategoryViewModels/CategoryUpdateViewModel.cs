namespace Pustok.BLL.ViewModels.CategoryViewModels
{
    public class CategoryUpdateViewModel:IViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int? ParentId { get; set; }
    }
}
