namespace Pustok.Core.Entities
{
    public class BasketItem : BaseEntity
    {
        public int ProductId { get; set; } 
        public Product? Product { get; set; } 
        public string? UserId { get; set; } 
        public int Quantity { get; set; } 
        public decimal Price { get; set; }
        public decimal TotalPrice => Price * Quantity; 

    }
}
