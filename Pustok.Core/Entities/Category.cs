namespace Pustok.Core.Entities
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int? ParentId { get; set; }  
        public Category? Parent { get; set; }  
        public ICollection<Category> Children { get; set; } = new List<Category>();  

        public ICollection<Product> Products { get; set; } = new List<Product>();  
    }
}
