namespace Pustok.BLL.ViewModels.CategoryViewModels
{
    public class CategoryViewModel:IViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int? ParentId { get; set; }
        public string? ParentName { get; set; }
        //public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();

    }
}
