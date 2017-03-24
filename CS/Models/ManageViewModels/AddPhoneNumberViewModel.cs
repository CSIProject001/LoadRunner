// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddPhoneNumberViewModel.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the AddPhoneNumberViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.ManageViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
