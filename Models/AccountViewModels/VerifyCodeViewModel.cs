// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VerifyCodeViewModel.cs" company="Microsoft">
//   Microsoft
// </copyright>
// <summary>
//   Defines the VerifyCodeViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace CS.Models.AccountViewModels
{
    /// <summary>
    /// The verify code view model.
    /// </summary>
    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        public string Code { get; set; }

        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
