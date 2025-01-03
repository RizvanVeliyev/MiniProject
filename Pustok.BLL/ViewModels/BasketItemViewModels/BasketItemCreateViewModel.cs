﻿namespace Pustok.BLL.ViewModels.BasketItemViewModels
{
    public class BasketItemCreateViewModel : IViewModel
    {
        public int ProductId { get; set; }
        public required string UserId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
