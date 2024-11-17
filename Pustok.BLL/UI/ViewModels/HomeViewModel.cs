using Pustok.BLL.ViewModels.CategoryViewModels;
using Pustok.BLL.ViewModels.ProductViewModels;
using Pustok.BLL.ViewModels.ServiceViewModels;
using Pustok.BLL.ViewModels.SliderViewModels;
using System.Security.Policy;

namespace Pustok.BLL.UI.ViewModels
{
    public class HomeViewModel
    {
        public List<ProductViewModel>? Products { get; set; }
        public List<CategoryViewModel>? Categories { get; set; }
        public List<SliderViewModel>? Sliders { get; set; }
        public List<ServiceViewModel> Services { get; set; }
    }
}
