using System.ComponentModel.DataAnnotations;

namespace Pustok.BLL.ViewModels.ContactViewModels
{
    public class ContactViewModel:IViewModel

    {
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Message { get; set; }
    }
}
