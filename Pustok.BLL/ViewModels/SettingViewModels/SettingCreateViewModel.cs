﻿namespace Pustok.BLL.ViewModels.SettingViewModels
{
    public class SettingCreateViewModel:IViewModel
    {
        public required string Key { get; set; }
        public required string Value { get; set; }
        public required string ContactNumber { get; set; }
    }

}
