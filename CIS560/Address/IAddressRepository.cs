using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560
{
    /// <summary>
    /// An interface for <see cref="AddressRepository"/>
    /// </summary>
    public interface IAddressRepository
    {

        /// <summary>
        /// Gets all the addresses in the table
        /// </summary>
        /// <returns>
        /// A <see cref="List{T}"/> of <see cref="Address">Addresses</see>/>.  This may be empty if none 
        /// are found in the databse.
        /// </returns>
        IReadOnlyList<Address> RetrieveAddresses();

        /// <summary>
        /// Gets an address with the given <code>addressId</code>
        /// </summary>
        /// <param name="addressId">The ID of the desired address</param>
        /// <returns>
        /// If found, an <see cref="Address"/> corresponding to the given <code>addressId</code>, otherwise <code>null</code>.
        /// </returns>
        Address GetAddress(int addressId);

        /// <summary>
        /// Creates a new address with the given parameters and inserts it into the database.
        /// </summary>
        /// <param name="line1">The first line of the address</param>
        /// <param name="line2">The second line of the address</param>
        /// <param name="city">The city of the address</param>
        /// <param name="state">The state of the address</param>
        /// <param name="zip">The zipcode of the address</param>
        /// <returns>A new <see cref="Address"/> if successful, otherwise <code>null</code></returns>
        Address CreateAddress(string line1, string line2, string city, string state, int zip);
    }
}
