using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560.OrderMenuItem
{
    public interface IOrderMenuItemRepository
    {
        IReadOnlyList<OrderMenuItem> RetrieveOrderMenuItems();
        OrderMenuItem GetOrderMenuItem(int orderId, int menuItemId);
        OrderMenuItem CreateOrderMenuItem(int orderId, int menuItemId, int menuItemQuantity);
    }
}
