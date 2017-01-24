using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS.Models.ProductViewModels
{
    /// <summary>
    /// The product repository holds all the products 
    /// </summary>
    public class ProductRepository : IRepository<Product>
    {
        /// <summary>
        /// Gets or sets the Items where Items = Products
        /// </summary>
        public IEnumerable<Product> Items { get; set; }
    }
}
