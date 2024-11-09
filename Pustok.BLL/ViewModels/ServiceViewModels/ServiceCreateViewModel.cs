namespace Pustok.BLL.ViewModels.ServiceViewModels
{
    public class ServiceCreateViewModel:IViewModel
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string IconUrl { get; set; }
    }
}
