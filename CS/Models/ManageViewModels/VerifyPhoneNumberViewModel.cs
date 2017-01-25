// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VerifyPhoneNumberViewModel.cs" company="Microsoft">
//   Microsoft Auto Generated Code
// </copyright>
// <summary>
//   Defines the VerifyPhoneNumberViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.ManageViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The verify phone number view model.
    /// </summary>
    public class VerifyPhoneNumberViewModel
    {
        [Required]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
