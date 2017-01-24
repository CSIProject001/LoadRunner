using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS.Models.ProductViewModels
{
    public class CustomerAddressesRepository:IRepository<CustomerAddress>
    {
        public IEnumerable<CustomerAddress> Items { get; set; }
    }
}
