using Microsoft.AspNetCore.Http;
using Pustok.BLL.ViewModels.ProductImageViewModels;
using Pustok.Core.Entities;

namespace Pustok.BLL.ViewModels.ProductViewModels
{
    public class ProductViewModel:IViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public string? ProductCode { get; set; }
        public string? Brand { get; set; }
        public string? Description { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string? Color { get; set; }
        public bool InStock { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int StockQuantity { get; set; }
        public decimal Rating { get; set; }
        public int CategoryId { get; set; }
        public required Category Category { get; set; }
        public decimal Tax { get; set; }
        public required string ImageUrl { get; set; }
        public int RewardPoint { get; set; }
        public ICollection<TagProduct>? ProductTags { get; set; }
        public IFormFile? MainImage { get; set; }
        public List<ProductImageViewModel>? ProductImages { get; set; }

        public string? MainImagePath { get; set; }
        public List<IFormFile> AdditionalImages { get; set; } = new();
        public List<string>? AdditionalImagePaths { get; set; } = new();
        public List<int> AdditionalImageIds { get; set; } = new();
        //public List<ProductImage> ProductImages { get; set; } = new();

    }
}
