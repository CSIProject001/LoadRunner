// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderItem.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the OrderItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.CandiSyrupViewModels
{
    public class OrderItem
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal OrderQuantity { get; set; }

        public decimal Price { get; set; }

        public string Coupon { get; set; }

        public int CouponPrice { get; set; }

        public decimal Total { get; set; }


    }
}
