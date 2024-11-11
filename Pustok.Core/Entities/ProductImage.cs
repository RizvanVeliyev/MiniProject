namespace Pustok.Core.Entities
{
    public class ProductImage : BaseEntity
    {
        public required string ImageUrl { get; set; } 
        public bool IsMain { get; set; } 
        public int ProductId { get; set; }
        public bool isDeleted { get; set; } = false;
        public required Product Product { get; set; }
    }
}
