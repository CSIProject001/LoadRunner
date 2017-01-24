// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerPhonesRepository.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the CustomerPhonesRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.ProductViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// The customer phones repository.
    /// </summary>
    public class CustomerPhonesRepository: IRepository<CustomerPhone>
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public IEnumerable<CustomerPhone> Items { get; set; }
    }
}
