namespace Pustok.BLL.ViewModels.SettingViewModels
{
    public class SettingUpdateViewModel:IViewModel
    {
        public int Id { get; set; }
        public required string Key { get; set; }
        public required string Value { get; set; }
        public required string ContactNumber { get; set; }
    }

}
