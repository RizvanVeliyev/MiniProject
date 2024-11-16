namespace Pustok.Core.Entities
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public int? ParentId { get; set; }  
        public Category? Parent { get; set; }  
        public ICollection<Category> Parents { get; set; } = new List<Category>();  

        public bool IsDeleted { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();  
    }
}
