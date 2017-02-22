// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Customer.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the ApplicationUser type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Customer 
    {
        // Primary Key definition
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public string Organization { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }
        
        // User ID from ASPNETUSERS - this ties up a Customer to a Login
        [Required]
        public string UserId { get; set; }

    }
}
