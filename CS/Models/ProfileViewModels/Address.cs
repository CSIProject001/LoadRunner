// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Address.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the Address type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.ProfileViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class Address
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }
        
        [Required]        
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Zip { get; set; }        

    }
}
