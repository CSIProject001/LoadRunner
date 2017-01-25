// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterViewModel.cs" company="Microsoft">
//   Microsoft Auto Generated Code
// </copyright>
// <summary>
//   Defines the RegisterViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The register view model.
    /// </summary>
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
