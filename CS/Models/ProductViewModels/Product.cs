// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Product.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the Product type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.ProductViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public int UnitsInOrder { get; set; }

        public int ReOrderLevel { get; set; }

        public bool IsActive { get; set; }

        public string ImageName { get; set; }

    }
}
