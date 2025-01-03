﻿using Microsoft.AspNetCore.Http;

namespace Pustok.BLL.ViewModels.SliderViewModels
{
    public class SliderUpdateViewModel : IViewModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public required string ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }


    }

}
