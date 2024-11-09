using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.BLL.ViewModels.TagViewModels
{

    public class TagViewModel : IViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
