using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS.Models.ProductViewModels
{
    public class OrderItem
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal OrderQuantity { get; set; }

        public decimal Price { get; set; } 

    }
}
