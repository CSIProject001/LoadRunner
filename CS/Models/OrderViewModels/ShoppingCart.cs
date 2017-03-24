// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShoppingCart.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   The shopping cart.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.OrderViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The shopping cart.
    /// </summary>
    public class ShoppingCart 
    {
        [Required]
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string UserId { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
