// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CartItem.cs" company="CandiSyrup">
//   VirtualHeights
// </copyright>
// <summary>
//   Defines the CartItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.OrderViewModels
{
    using System.ComponentModel.DataAnnotations;

    using CS.Models.ProductViewModels;

    public class CartItem
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public Product Item { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        [DisplayFormat(DataFormatString = "D")]
        [Range(1, 1000, ErrorMessage = "{0} must be between {1} and {2}")]
        [RegularExpression(@"^\$?\d+$")]
        public decimal Quantity { get; set; }
        [Required]
        [Display(Name = "Unit Price")]
        [DisplayFormat(DataFormatString = "N")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal UnitPrice { get; set; }
        [Required]
        [Display(Name = "Cost")]
        [DisplayFormat(DataFormatString = "N")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal Price { get; set; }
        
        [Display(Name = "Coupon Code")]
        public string Coupon { get; set; }

        [Display(Name = "Discount Price")]
        [DisplayFormat(DataFormatString = "N")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal DiscountPrice { get; set; }
    }
}
