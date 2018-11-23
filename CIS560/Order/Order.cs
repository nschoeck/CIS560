using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560
{
    /// <summary>
    /// An object representing an order
    /// </summary>
    public class Order
    {
        private int orderId { get; }
        private int customerId { get; }
        private int driverId { get; }
        private int addressId { get; }
        private DateTime createdOn { get; }

        public Order(int orderId, int customerId, int driverId, int addressId)
        {
            this.orderId = orderId;
            this.customerId = customerId;
            this.driverId = driverId;
            this.addressId = addressId;
            this.createdOn = DateTime.Now;
        }
    }
}
