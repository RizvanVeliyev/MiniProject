using Microsoft.AspNetCore.Identity;

namespace Pustok.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public bool IsActive { get; set; } = true;
    }
}