using Microsoft.AspNetCore.Http;

namespace Pustok.BLL.ViewModels.SliderViewModels
{
    public class SliderCreateViewModel : IViewModel
    {
        public required string Title { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public required IFormFile ImageFile { get; set; }
    }

}
