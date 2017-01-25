// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   The Repository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Models.ProductViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    /// <typeparam name="T">
    /// Products, Orders, Address, anything that needs a repository
    /// </typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        IEnumerable<T> Items { get; set; }
    }
}
