// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Phone.cs" company="CandiSyrup">
//   VirtualHeights
// </copyright>
// <summary>
//   Defines the Phone type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.DBModels
{
    using System.Collections.Generic;

    public class Phone
    {
        public Dictionary<string, string> PhoneCategories { get; } = new Dictionary<string, string>
                {
                    { "HOME", "Home" },
                    { "MOBILE", "Mobile" },
                    { "WORK", "work" },
                    { "MOBILE2", "Mobile2" },
                    { "WORK2", "Work2" },
                    { "OTHER", "other" }
                };

        public int ID { get; set; }

        public string Category { get; set; }  

       public string PhoneNumber { get; set; }
    }
}
