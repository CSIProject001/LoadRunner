// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Address.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the Address type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.ProductViewModels
{
    public class Address
    {
        public int Id { get; set; }
                
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Zip { get; set; }        

    }
}
