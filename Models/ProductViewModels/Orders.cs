using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS.Models.ProductViewModels
{
    public class Orders: IRepository<Order>
    {
        public IEnumerable<Order> Items { get; set; }
    }
}
