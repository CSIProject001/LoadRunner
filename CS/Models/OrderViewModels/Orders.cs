// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Orders.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the Orders type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.OrderViewModels
{
    using System.Collections.Generic;

    public class Orders
    {
        public ICollection<Order> OrderCollection { get; set; }
    }
}
