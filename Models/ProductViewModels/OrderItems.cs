// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderItems.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the OrderItems type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.ProductViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// The order Items.
    /// </summary>
    public class OrderItemsRepository : IRepository<OrderItem>
    {
        /// <summary>
        /// Gets or sets the Items.
        /// </summary>
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
