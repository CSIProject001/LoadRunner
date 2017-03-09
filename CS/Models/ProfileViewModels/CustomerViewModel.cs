// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerViewModel.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the CustomerViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.ProfileViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CS.Models.DBModels;

    public class CustomerViewModel
    {
       

        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public CS.Models.ApplicationUser User { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<Phone> Phones { get; set; }
    }
}
