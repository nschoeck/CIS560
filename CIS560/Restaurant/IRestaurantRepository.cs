using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560
{
    public interface IRestaurantRepository
    {
        IReadOnlyList<Restaurant> RetrieveRestaurants();
        Restaurant GetRestaurant(int restaurantId);
        Restaurant CreateRestaurant(string name, int addressId);
    }
}
