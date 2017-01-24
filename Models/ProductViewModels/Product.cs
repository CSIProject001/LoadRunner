using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS.Models.ProductViewModels
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public int UnitsInOrder { get; set; }

        public int ReOrderLevel { get; set; }

        public bool IsActive { get; set; }
    }
}
