using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560.Order
{
    public interface IOrderRepository
    {
        IReadOnlyList<Order> RetrieveOrders();
        Order GetOrder(int orderId);
        Order CreateOrder(int orderId, int customerId, int driverId, int addressId);
    }
}
