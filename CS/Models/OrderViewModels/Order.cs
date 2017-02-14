// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Order.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   The order.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.OrderViewModels
{
    using System;
    using System.Collections.Generic;

    using CS.Models.CandiSyrupViewModels;

    /// <summary>
    /// The order.
    /// </summary>
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string OrderNumber  { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ShippedDate { get; set; }

        public int ShippingAddressId { get; set; }

        public int BillingAddressId { get; set; }

        public decimal OrderTotal { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Tax { get; set; }

        public string PromotionCode { get; set; }

        public decimal PromotionAmount { get; set; }

        public decimal ShippingWeightTotal { get; set; }

        public string TrackingCode  { get; set; }

        public string CCAuthorizationCode { get; set; }

        public string ShippingVia { get; set; }

        public DateTime OrderReceivedDate { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
