namespace Pustok.BLL.ViewModels.BasketItemViewModels
{
    public class BasketItemCreateViewModel : IViewModel
    {
        public int ProductId { get; set; }
        public required string UserId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class BasketItemUpdateViewModel : IViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public required string UserId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class BasketItemViewModel : IViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImageUrl { get; set; }
        public string? UserId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Price * Quantity;
    }
}
