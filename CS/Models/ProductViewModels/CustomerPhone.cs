// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerPhone.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the CustomerPhone type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.ProductViewModels
{
    /// <summary>
    /// The customer phone.
    /// </summary>
    public class CustomerPhone
    {
        public int CustomerId { get; set; }

        public int PhoneId { get; set; }

        public int PhoneCategoryId { get; set; }    
    }
}
