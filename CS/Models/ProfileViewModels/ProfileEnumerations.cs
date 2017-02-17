// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileEnumerations.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the ProfileEnumerations type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.ProfileViewModels
{
    using System.Collections.Generic;

    public static class ProfileEnumerations
    {
        static ProfileEnumerations()
        {
            PhoneCategories = new List<string> { "Home", "Mobile", "Work", "Other", "Mobile2" };
            AddressCategories = new List<string> { "Billing", "Shipping", "Home", "Shipping2", "Billing2","Other" };
        }

        public static List<string> PhoneCategories { get; set; }

        public static List<string> AddressCategories { get; set; }
    }
}
