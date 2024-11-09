namespace Pustok.BLL.ViewModels.ProductImageViewModels
{
    public class ProductImageCreateViewModel:IViewModel
    {
        public required string ImageUrl { get; set; }
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
    }

}
