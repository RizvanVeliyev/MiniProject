using Pustok.DAL.Enums;

namespace Pustok.BLL.ViewModels.AppUserViewModels
{
    public class ChangeRoleViewModel:IViewModel
    {
        public required string UserId { get; set; }
        public IdentityRoles NewRole { get; set; }
    }
}
