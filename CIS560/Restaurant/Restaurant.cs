using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560
{
    public class Restaurant
    {
        private int restaurantId { get; }
        private string name { get; }
        private int addressId { get; }

        public Restaurant(int restaurantId, string name, int addressId)
        {
            this.restaurantId = restaurantId;
            this.name = name;
            this.addressId = addressId;
        }
    }
}
