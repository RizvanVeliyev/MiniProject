namespace Pustok.Core.Entities
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public string? ProductCode { get; set; }
        public string? Brand { get; set; }
        public string? Description { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string? Color { get; set; }
        public bool InStock { get; set; }
        public bool IsDeleted { get; set; }
        public int StockQuantity { get; set; }
        public decimal Rating { get; set; }
        public List<ProductImage> ProductImages { get; set; } = new();
        public int CategoryId { get; set; }
        public required Category Category { get; set; }
        public decimal Tax { get; set; }
        public int RewardPoint { get; set; }

        public ICollection<TagProduct>? ProductTags { get; set; }

    }
}
