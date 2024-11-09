namespace Pustok.BLL.ViewModels.SubscribeViewModels
{
    public class SubscribeUpdateViewModel : IViewModel
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public bool IsSubscribed { get; set; }
    }
}
