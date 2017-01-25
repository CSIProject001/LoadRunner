// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerAddress.cs" company="CandiSyrup">
//   VirtualHeights
// </copyright>
// <summary>
//   Defines the CustomerAddress type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.ProductViewModels
{
    public class CustomerAddress
    {
        public int CustomerId { get; set; }

        public int AddressId { get; set; }

        public int AddressCategoryId { get; set; } 
    }
}
