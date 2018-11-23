using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560
{
    /// <summary>
    /// An interface for <see cref="RestaurantRepository"/>
    /// </summary>
    public interface IRestaurantRepository
    {
        /// <summary>
        /// Retrieves all restaurants from the database
        /// </summary>
        /// <returns>
        /// A <see cref="List{T}"/> of all <see cref="Restaurant"/>s in the databse, or an empty list if there are none.
        /// </returns>
        IReadOnlyList<Restaurant> RetrieveRestaurants();

        /// <summary>
        /// Gets a restaurant from the database
        /// </summary>
        /// <param name="restaurantId">The ID of the desired restaurant</param>
        /// <returns>A <see cref="Restaurant"/> with the information on the ID given, or <code>null</code> if no restaurant 
        /// was found matching the given ID</returns>
        Restaurant GetRestaurant(int restaurantId);

        /// <summary>
        /// Creates a restaurant in the database
        /// </summary>
        /// <param name="name">The name of the restaurant</param>
        /// <param name="addressId">The ID of the <see cref="Address"/> of the restaurant</param>
        /// <returns>
        /// A <see cref="Restaurant"/> containing the information of the entry created in the databse, or null if the entry
        /// could not be created in the database
        /// </returns>
        Restaurant CreateRestaurant(string name, int addressId);
    }
}
