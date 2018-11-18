using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560.Restaurant
{
    public interface IRestaurantRepository
    {
        IReadOnlyList<Restaurant> RetrieveRestaurants();
        Restaurant GetRestaurant(int restaurantId);
        Restaurant CreateRestaurant(int restaurantId, string name, int addressId);
    }
}
