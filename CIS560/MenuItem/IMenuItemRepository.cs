using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560.MenuItem
{
    public interface IMenuItemRepository
    {
        IReadOnlyList<MenuItem> RetrieveMenuItems();
        MenuItem GetMenuItem(int menuItemId);
        MenuItem CreateMenuItem(int menuItemId, int restaurantId, string name, decimal price);
    }
}
