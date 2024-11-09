namespace Pustok.BLL.ViewModels.SettingViewModels
{

    public class SettingViewModel:IViewModel
    {
        public int Id { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public string? ContactNumber { get; set; }
    }

}
