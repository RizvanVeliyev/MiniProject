namespace Pustok.BLL.ViewModels.SliderViewModels
{

    public class SliderViewModel : IViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }

}
