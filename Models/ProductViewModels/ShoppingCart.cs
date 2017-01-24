// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShoppingCart.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   The shopping cart.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.ProductViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// The shopping cart.
    /// </summary>
    public class ShoppingCart : IRepository<CartItem>
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public IEnumerable<CartItem> Items { get; set; }
    }
}
