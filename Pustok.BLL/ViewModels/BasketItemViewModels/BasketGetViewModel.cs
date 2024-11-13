using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.BLL.ViewModels.BasketItemViewModels
{
    public class BasketGetViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string ImagePath { get; set; } = null!;
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
