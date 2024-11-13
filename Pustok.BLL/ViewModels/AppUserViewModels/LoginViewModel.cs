namespace Pustok.BLL.ViewModels.AppUserViewModels
{
    public class LoginViewModel
    {
        public required string EmailOrUserName { get; set; }
        public required string Password { get; set; }
        public bool SaveMe { get; set; } = false;
    }
}
