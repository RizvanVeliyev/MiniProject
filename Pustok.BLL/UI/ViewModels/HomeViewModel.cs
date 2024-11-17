using Pustok.BLL.ViewModels.CategoryViewModels;
using Pustok.BLL.ViewModels.ProductViewModels;
using Pustok.BLL.ViewModels.SliderViewModels;

namespace Pustok.BLL.UI.ViewModels
{
    public class HomeViewModel
    {
        public List<ProductViewModel>? Products { get; set; }
        public List<CategoryViewModel>? Categories { get; set; }
        public List<SliderViewModel>? Sliders { get; set; }
    }
}
