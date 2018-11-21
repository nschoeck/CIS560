using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560
{
    public class OrderMenuItem
    {
        private int orderId { get; }
        private int menuItemId { get; }
        private int menuItemQuantity { get; }

        public OrderMenuItem(int orderId, int menuItemId, int menuItemQuantity)
        {
            this.orderId = orderId;
            this.menuItemId = menuItemId;
            this.menuItemQuantity = menuItemQuantity;
        }
    }
}
