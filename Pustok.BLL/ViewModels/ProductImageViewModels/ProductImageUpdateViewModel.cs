namespace Pustok.BLL.ViewModels.ProductImageViewModels
{
    public class ProductImageUpdateViewModel:IViewModel
    {
        public int Id { get; set; }
        public required string ImageUrl { get; set; }
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
    }

}
