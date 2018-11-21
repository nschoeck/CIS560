using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560
{
    public interface ICustomerRepository
    {
        IReadOnlyList<Customer> RetrieveCustomers();
        Customer GetCustomer(int customerId);
        Customer CreateCustomer(string firstName, string lastName, int primaryAddressId, string email, int phoneNumber);
    }
}
