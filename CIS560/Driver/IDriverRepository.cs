using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560.Driver
{
    public interface IDriverRepository
    {
        IReadOnlyList<Driver> RetrieveDrivers();
        Driver GetDriver(int driverId);
        Driver CreateDriver(int driverId, string firstName, string lastName, string driversLicenseNumber);
    }
}
