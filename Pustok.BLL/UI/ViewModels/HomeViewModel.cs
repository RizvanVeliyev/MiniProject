using Pustok.BLL.ViewModels.CategoryViewModels;
using Pustok.BLL.ViewModels.ProductViewModels;
using Pustok.BLL.ViewModels.ServiceViewModels;
using Pustok.BLL.ViewModels.SliderViewModels;
using Pustok.Core.Paging;
using System.Security.Policy;

namespace Pustok.BLL.UI.ViewModels
{
    public class HomeViewModel
    {
        public Paginate<ProductViewModel>? Products { get; set; }
        public Paginate<CategoryViewModel>? Categories { get; set; }
        public Paginate<SliderViewModel>? Sliders { get; set; }
        public Paginate<ServiceViewModel>? Services { get; set; }
    }
}
