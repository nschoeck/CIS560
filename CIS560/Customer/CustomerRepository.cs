using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560
{
    class CustomerRepository : ICustomerRepository
    {
        public Customer CreateCustomer(string firstName, string lastName, int primaryAddressId, string email, int phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Customer> RetrieveCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
