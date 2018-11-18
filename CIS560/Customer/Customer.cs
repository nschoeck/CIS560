using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560.Customer
{
    public class Customer
    {
        private int customerId { get; }
        private string firstName { get; }
        private string lastName { get; }
        private int primaryAddressId { get; }
        private string email { get; }
        private int phoneNumber { get; }

        public Customer(int customerId, string firstName, string lastName, int primaryAddressId, string email, int phoneNumber)
        {
            this.customerId = customerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.primaryAddressId = primaryAddressId;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }
    }
}
