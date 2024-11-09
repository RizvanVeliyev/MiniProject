namespace Pustok.BLL.ViewModels.ServiceViewModels
{
    public class ServiceViewModel:IViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? IconUrl { get; set; }
    }
}
