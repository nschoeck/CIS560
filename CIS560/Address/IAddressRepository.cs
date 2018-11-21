using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560
{
    public interface IAddressRepository
    {
        IReadOnlyList<Address> RetrieveAddresses();
        Address GetAddress(int addressId);
        Address CreateAddress(int addressId, string line1, string line2, string city, string state, int zip);
    }
}
