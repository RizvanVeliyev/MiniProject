namespace Pustok.BLL.ViewModels.SubscribeViewModels
{
    public class SubscribeCreateViewModel : IViewModel
    {
        public required string Email { get; set; }
        public bool IsSubscribed { get; set; }
    }
}
