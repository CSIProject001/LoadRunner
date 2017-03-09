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
        public int ID { get; set; }

        public string Category { get; set; }  

       public string PhoneNumber { get; set; }
    }
}
