namespace Pustok.BLL.ViewModels.CategoryViewModels
{
    public class CategoryViewModel : IViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int? ParentId { get; set; }
        public CategoryViewModel? Parent { get; set; }
        //public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();

    }
}
