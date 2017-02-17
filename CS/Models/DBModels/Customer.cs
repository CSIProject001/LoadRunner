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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Customer 
    {
        [Key]
        public int ID { get; set; }
     
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }



    }
}
