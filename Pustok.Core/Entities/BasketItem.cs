namespace Pustok.Core.Entities
{
    public class BasketItem : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public AppUser? AppUser { get; set; }
        public string? AppUserId { get; set; }//Null! yazmaliyam amma ele yazanda islemir
        public int Count { get; set; } 
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }

        public decimal TotalPrice => Price * Count; 

    }
}
