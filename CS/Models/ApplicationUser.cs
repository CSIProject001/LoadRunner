// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationUser.cs" company="Candisysrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the ApplicationUser type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

    }
}
