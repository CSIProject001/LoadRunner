// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GlobalCategories.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the GlobalCategories type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace CS.Models.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    public static class GlobalCategories
    {
        public static List<SelectListItem> ProductCategories { get; set; } = new List<SelectListItem>
                {
                    new SelectListItem
                        {
                            Text = "Category 1",
                            Value = "1"
                        },
                    new SelectListItem
                        {
                            Text = "Category 2",
                            Value = "2"
                        },
                    new SelectListItem
                        {
                            Text = "Category 3",
                            Value = "3"
                        }
                };
        public static List<SelectListItem> PhoneCategories { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Text = "Home", Value="Home"},
            new SelectListItem { Text = "Mobile", Value="Mobile"},
            new SelectListItem { Text = "Work", Value="Work"},
            new SelectListItem { Text = "Home", Value="Home"},
            new SelectListItem { Text = "Home", Value="Home"},
            new SelectListItem { Text = "Home", Value="Home"},

        };
    }
}
