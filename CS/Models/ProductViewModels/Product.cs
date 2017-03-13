// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Product.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the Product type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CS.Models.ProductViewModels
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        [StringLength(100,ErrorMessage = "{0} must be less than {1} characters")]
        public string Name { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Quantity Per Unit")]
        [Range(1, 1000, ErrorMessage = "{0} must be between {1} and {2}")]
        [RegularExpression(@"^\$?\d+$")]
        [DefaultValue(1)]
        public string QuantityPerUnit { get; set; }

        [Required]
        [Display(Name = "Unit Price")]
        [DefaultValue(1.00)]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Display(Name = "Units In Stock")]
        [Range(1, 1000, ErrorMessage = "{0} must be between {1} and {2}")]
        [RegularExpression(@"^\$?\d+$")]
        [DefaultValue(1)]
        public int UnitsInStock { get; set; }

        [Required]
        [Display(Name = "Units in Order")]
        [DefaultValue(0)]
        [Range(1,1000, ErrorMessage = "{0} must be between {1} and {2}")]
        public int UnitsInOrder { get; set; }

        [Required]
        [Display(Name = "ReOrder Level")]
        [RegularExpression(@"^\$?\d+$")]
        [DefaultValue(1)]
        [Range(1, 1000, ErrorMessage = "{0} must be between {1} and {2}")]
        public int ReOrderLevel { get; set; }

        [Display(Name = "Is Active?")]
        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "Product Image Name")]
        [StringLength(500, ErrorMessage = "{0} must be less than {1} characters")]
        public string ImageName { get; set; }

        //[Display(Name = "Description")]
        //[StringLength(500, ErrorMessage = "{0} must be less than {1} characters")]
        //public string Description { get; set; }
    }
}
