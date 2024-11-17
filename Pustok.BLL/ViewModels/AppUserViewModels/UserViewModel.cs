﻿namespace Pustok.BLL.ViewModels.AppUserViewModels
{
    public class UserViewModel : IViewModel
    {
        public string? Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
        public List<string> Roles { get; set; } = [];
    }
}
