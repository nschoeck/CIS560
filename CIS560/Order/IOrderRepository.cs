using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560
{
    public interface IOrderRepository
    {
        IReadOnlyList<Order> RetrieveOrders();
        Order GetOrder(int orderId);
        Order CreateOrder(int customerId, int driverId, int addressId);
    }
}
