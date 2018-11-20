using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560
{
    public interface IDriverRepository
    {
        IReadOnlyList<Driver> RetrieveDrivers();
        Driver GetDriver(int driverId);
        Driver CreateDriver(string firstName, string lastName, string driversLicenseNumber);
    }
}
