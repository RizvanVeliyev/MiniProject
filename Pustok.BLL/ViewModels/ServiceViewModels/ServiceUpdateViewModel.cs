namespace Pustok.BLL.ViewModels.ServiceViewModels
{
    public class ServiceUpdateViewModel:IViewModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string IconUrl { get; set; }
    }
}
