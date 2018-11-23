using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560
{
    /// <summary>
    /// An interface for <see cref="OrderRepository"/>
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Retrieves all orders from the database
        /// </summary>
        /// <returns>
        /// A <see cref="List{T}"/> of <see cref="Order"/> from the database. 
        /// This will return empty if no orders are found.
        /// </returns>
        IReadOnlyList<Order> RetrieveOrders();

        /// <summary>
        /// Gets an order from the database
        /// </summary>
        /// <param name="orderId">The ID of the order to get</param>
        /// <returns>An <see cref="Order"/> containing the information on the provided ID.  
        /// This will return null if no order was found containing the given <code>orderId</code>
        /// </returns>
        Order GetOrder(int orderId);

        /// <summary>
        /// Creates an order in the database
        /// </summary>
        /// <param name="customerId">The ID of the <see cref="Customer"/> placing the order</param>
        /// <param name="driverId">The ID of the <see cref="Driver"/> delivering the order</param>
        /// <param name="addressId">The ID of the <see cref="Address"/> the order is being delivered to</param>
        /// <returns>The created <see cref="Order"/> if successful, otherwise null</returns>
        Order CreateOrder(int customerId, int driverId, int addressId);
    }
}
