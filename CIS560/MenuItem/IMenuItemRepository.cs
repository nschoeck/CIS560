using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560
{
    /// <summary>
    /// The interface for <see cref="MenuItemRepository"/>
    /// </summary>
    public interface IMenuItemRepository
    {
        /// <summary>
        /// Gets all menu items from the database
        /// </summary>
        /// <returns>
        /// A <see cref="List{T}"/> of <see cref="MenuItem"/>.  This list may be empty if there are no menu items in the database.
        /// </returns>
        IReadOnlyList<MenuItem> RetrieveMenuItems();

        /// <summary>
        /// Gets a menu item from the databse
        /// </summary>
        /// <param name="menuItemId">The ID of the desired menu item</param>
        /// <returns>
        /// A <see cref="MenuItem"/> with the information corresponding to the <code>menuItemId</code>.  
        /// This will be null if no menu item with the passed menuItemId exists.
        /// </returns>
        MenuItem GetMenuItem(int menuItemId);

        /// <summary>
        /// Creates a menu item in the databse
        /// </summary>
        /// <param name="restaurantId">The ID of the restaurant this menu item belongs to</param>
        /// <param name="name">The name of the menu item</param>
        /// <param name="price">The cost of the menu item</param>
        /// <returns>A <see cref="MenuItem"/> containing the information provided, or null if the menu item couldn't be created</returns>
        MenuItem CreateMenuItem(int restaurantId, string name, decimal price);
    }
}
