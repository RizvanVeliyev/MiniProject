using Microsoft.AspNetCore.Http;
using Pustok.Core.Entities;

namespace Pustok.BLL.ViewModels.ProductImageViewModels
{

    public class ProductImageViewModel:IViewModel
    {
        public int Id { get; set; }
        //public required IFormFile ImageFile { get; set; }
        public required string ImageUrl { get; set; }
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public bool isDeleted { get; set; } = false;
    }

}
