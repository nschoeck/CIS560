using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560
{
    /// <summary>
    /// An interface for <see cref="OrderMenuItem"/>
    /// </summary>
    public interface IOrderMenuItemRepository
    {
        /// <summary>
        /// Retrieves all <see cref="OrderMenuItem"/>s from the database.
        /// </summary>
        /// <returns>
        /// A <see cref="List{T}"/> of <see cref="OrderMenuItem"/>s found in the database.
        /// If none are found this will return an empty list.
        /// </returns>
        IReadOnlyList<OrderMenuItem> RetrieveOrderMenuItems();

        /// <summary>
        /// Gets an <see cref="OrderMenuItem"/> from the database
        /// </summary>
        /// <param name="orderId">The ID of the desired <see cref="Order"/></param>
        /// <param name="menuItemId">The ID of the desired <see cref="MenuItem"/></param>
        /// <returns>
        /// An <see cref="OrderMenuItem"/> containing the information of the <code>orderId</code> and <code>menuItemId</code> if found.
        /// If nothing corresponds to the given <code>orderId</code> and <code>menuItemId</code> this will return null.
        /// </returns>
        OrderMenuItem GetOrderMenuItem(int orderId, int menuItemId);

        /// <summary>
        /// Creates an order menu item in the database
        /// </summary>
        /// <param name="orderId">The ID of the <see cref="Order"/></param>
        /// <param name="menuItemId">The ID of th <see cref="MenuItem"/></param>
        /// <param name="menuItemQuantity">The quantity purchased of the <see cref="MenuItem"/></param>
        /// <returns>
        /// An <see cref="OrderMenuItem"/> of the created order menu item, or null if the order menu item couldn't be created in the databse.
        /// </returns>
        OrderMenuItem CreateOrderMenuItem(int orderId, int menuItemId, int menuItemQuantity);
    }
}
