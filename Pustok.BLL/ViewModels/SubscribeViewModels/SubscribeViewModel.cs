namespace Pustok.BLL.ViewModels.SubscribeViewModels
{

    public class SubscribeViewModel : IViewModel
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public bool IsSubscribed { get; set; }
    }
}
