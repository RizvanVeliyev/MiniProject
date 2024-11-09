namespace Pustok.BLL.ViewModels.SliderViewModels
{
    public class SliderCreateViewModel : IViewModel
    {
        public required string Title { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public required string ImageUrl { get; set; }
    }

}
