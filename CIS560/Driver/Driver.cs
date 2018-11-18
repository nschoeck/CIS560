using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560.Driver
{
    public class Driver
    {
        int driverId { get; }
        string firstName { get; }
        string lastName { get; }
        string driversLicenseNumber { get; }

        public Driver(int driverId, string firstName, string lastName, string driversLicenseNumber)
        {
            this.driverId = driverId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.driversLicenseNumber = driversLicenseNumber;
        }
    }
}
