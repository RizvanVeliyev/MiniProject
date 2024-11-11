using Microsoft.AspNetCore.Http;
using Pustok.Core.Entities;

namespace Pustok.BLL.ViewModels.ProductImageViewModels
{
    public class ProductImageUpdateViewModel:IViewModel
    {
        public required IFormFile ImageFile { get; set; }
        public required string ImageUrl { get; set; }
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
        public required Product Product { get; set; }
    }

}
