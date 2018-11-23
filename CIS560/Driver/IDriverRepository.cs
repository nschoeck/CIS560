using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560
{
    /// <summary>
    /// The interface for <see cref="DriverRepository"/>
    /// </summary>
    public interface IDriverRepository
    {
        /// <summary>
        /// Gets all the drivers in the database
        /// </summary>
        /// <returns>
        /// A <see cref="List{T}"/> of <see cref="Driver"/>s in the database, or empty if there are none.
        /// </returns>
        IReadOnlyList<Driver> RetrieveDrivers();

        /// <summary>
        /// Gets the driver with the given <code>driverId</code>
        /// </summary>
        /// <param name="driverId">The ID of the desired driver</param>
        /// <returns>
        /// A <see cref="Driver"/> with the given <code>driverId</code> if found, otherwise <code>null</code>
        /// </returns>
        Driver GetDriver(int driverId);

        /// <summary>
        /// Creates a driver in the database
        /// </summary>
        /// <param name="firstName">The first name of the driver</param>
        /// <param name="lastName">The last name of the driver</param>
        /// <param name="driversLicenseNumber">The drivers license number of the driver</param>
        /// <returns>The created <see cref="Driver"/> if successful, otherwise <code>null</code></returns>
        Driver CreateDriver(string firstName, string lastName, string driversLicenseNumber);
    }
}
