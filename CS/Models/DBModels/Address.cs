// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Address.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the Address type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.DBModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Address
    {
        public Dictionary<string, string> AddressCategories { get; } = new Dictionary<string, string>
                {
                    { "HOME", "Home" },
                    { "BILLING", "Billing" },
                    { "WORK", "work" },
                    { "SHIPPING", "Shipping" },
                    { "OTHER", "other" }
                };

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Category { get; set; }
        
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Zip { get; set; }        

    }
}
