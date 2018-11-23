using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560
{
    /// <summary>
    /// Interface for the <see cref="CustomerRepository"/>
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Gets all customers in the database
        /// </summary>
        /// <returns>
        /// A <see cref="List{T}"/> of every <see cref="Customer"/> in the database, or an empty list if none are found
        /// </returns>
        IReadOnlyList<Customer> RetrieveCustomers();

        /// <summary>
        /// Gets a <see cref="Customer"/> from the table.
        /// </summary>
        /// <param name="customerId">The ID of the desired <see cref="Customer"/></param>
        /// <returns>
        /// The <see cref="Customer"/> containing the <code>customerId</code>, or <code>null</code> if there is none
        /// </returns>
        Customer GetCustomer(int customerId);

        /// <summary>
        /// Creates a <see cref="Customer"/> in the database
        /// </summary>
        /// <param name="firstName">The first name of the customer</param>
        /// <param name="lastName">The last name of the customer</param>
        /// <param name="primaryAddressId">The primary address of the customer</param>
        /// <param name="email">The email of the customer</param>
        /// <param name="phoneNumber">The phone number of the customer</param>
        /// <returns>The <see cref="Customer"/> created if successful, otherwise <code>null</code></returns>
        Customer CreateCustomer(string firstName, string lastName, int primaryAddressId, string email, int phoneNumber);
    }
}
