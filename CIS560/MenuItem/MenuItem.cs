using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560
{
    public class MenuItem
    {
        private int menuItemId { get; }
        private int restaurantId { get; }
        private string name { get; }
        private decimal price { get; }

        public MenuItem(int menuItemId, int restaurantId, string name, decimal price)
        {
            this.menuItemId = menuItemId;
            this.restaurantId = restaurantId;
            this.name = name;
            this.price = price;
        }
    }
}
