// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShoppingCart.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   The shopping cart.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using CS.Models.ProductViewModels;

namespace CS.Models.OrderViewModels
{
    using Models;

    /// <summary>
    /// The shopping cart.
    /// </summary>
    public class ShoppingCart 
    {
        public int ID { get; set; }

        public Product Item { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Price { get; set; }

        public string Coupon { get; set; }

        public decimal DiscountPrice { get; set; }
    }
}
