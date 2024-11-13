using Pustok.Core.Entities;

namespace Pustok.BLL.ViewModels.BasketItemViewModels
{

    public class BasketItemViewModel : IViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImageUrl { get; set; }
        public string? UserId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Price * Count;
    }
}
