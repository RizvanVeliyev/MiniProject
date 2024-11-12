using Microsoft.AspNetCore.Http;
using Pustok.Core.Entities;

namespace Pustok.BLL.ViewModels.ProductViewModels
{
    public class ProductCreateViewModel:IViewModel
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public string? ProductCode { get; set; }
        public string? Brand { get; set; }
        public string? Description { get; set; }
        public decimal? DiscountPrice { get; set; }
        public required string ImageUrl { get; set; }
        public string? Color { get; set; }
        public bool InStock { get; set; }
        public int StockQuantity { get; set; }
        public decimal Rating { get; set; }
        public int CategoryId { get; set; }
        public required Category Category { get; set; }
        public decimal Tax { get; set; }
        public int RewardPoint { get; set; }
        public ICollection<TagProduct>? ProductTags { get; set; }
        public IFormFile MainImage { get; set; } = null!;
        public List<IFormFile> AdditionalImages { get; set; } = new();
    }
}
