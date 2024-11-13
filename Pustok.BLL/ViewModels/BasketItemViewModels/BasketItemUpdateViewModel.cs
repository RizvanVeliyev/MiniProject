namespace Pustok.BLL.ViewModels.BasketItemViewModels
{
    public class BasketItemUpdateViewModel : IViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public required string UserId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
