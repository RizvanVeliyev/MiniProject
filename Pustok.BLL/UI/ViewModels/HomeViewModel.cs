using Pustok.BLL.ViewModels.CategoryViewModels;
using Pustok.BLL.ViewModels.ProductViewModels;

namespace Pustok.BLL.UI.ViewModels
{
    public class HomeViewModel
    {
        public List<ProductViewModel>? Products { get; set; }
        public List<CategoryViewModel>? Categories { get; set; }
    }
}
