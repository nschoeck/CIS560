using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using System.Data.SqlClient;

namespace CIS560
{
    /// <summary>
    /// Repository for getting and creating <see cref="Restaurant"/>s in the database.
    /// </summary>
    class RestaurantRepository : IRestaurantRepository
    {
        SqlConnectionStringBuilder sqlBuilder = SqlBuilder.SqlConnectingStringBuilder;

        /// <summary>
        /// Creates a restaurant in the database
        /// </summary>
        /// <param name="name">The name of the restaurant</param>
        /// <param name="addressId">The ID of the <see cref="Address"/> of the restaurant</param>
        /// <returns>
        /// A <see cref="Restaurant"/> containing the information of the entry created in the databse, or null if the entry
        /// could not be created in the database
        /// </returns>
        public Restaurant CreateRestaurant(string name, int addressId)
        {
            const string sqlCommandText = "CIS560.CreateRestaurant";

            try
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    using (SqlConnection connection = new SqlConnection(sqlBuilder.ConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand(sqlCommandText, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("Name", name);
                            command.Parameters.AddWithValue("AddressID", addressId);

                            SqlParameter param = command.Parameters.Add("AddressID", SqlDbType.Int);
                            param.Direction = ParameterDirection.Output;

                            connection.Open();

                            command.ExecuteNonQuery();

                            transaction.Complete();

                            return new Restaurant((int)param.Value, name, addressId);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not create restaurant.  Exited with: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets a restaurant from the database
        /// </summary>
        /// <param name="restaurantId">The ID of the desired restaurant</param>
        /// <returns>A <see cref="Restaurant"/> with the information on the ID given, or <code>null</code> if no restaurant 
        /// was found matching the given ID</returns>
        public Restaurant GetRestaurant(int restaurantId)
        {
            //TODO: Set command
            string sqlCommandText = "CIS560.GetRestaurant";
            using (SqlConnection connection = new SqlConnection(sqlBuilder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlCommandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("RestaurantID", restaurantId);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (!reader.Read())
                    {
                        return null;
                    }

                    return new Restaurant(
                        restaurantId,
                        reader.GetString(reader.GetOrdinal("Name")),
                        reader.GetInt32(reader.GetOrdinal("AddressID"))
                    );
                }
            }
        }

        /// <summary>
        /// Retrieves all restaurants from the database
        /// </summary>
        /// <returns>
        /// A <see cref="List{T}"/> of all <see cref="Restaurant"/>s in the databse, or an empty list if there are none.
        /// </returns>
        public IReadOnlyList<Restaurant> RetrieveRestaurants()
        {
            //TODO: Set command here
            string sqlCommandText = "CIS560.RetrieveRestaurants";
            using (SqlConnection connection = new SqlConnection(sqlBuilder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlCommandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    List<Restaurant> restaurants = new List<Restaurant>();

                    while (reader.Read())
                    {
                        restaurants.Add(new Restaurant(
                            reader.GetInt32(reader.GetOrdinal("RestaurantID")),
                            reader.GetString(reader.GetOrdinal("Name")),
                            reader.GetInt32(reader.GetOrdinal("AddressID"))
                        ));
                    }

                    return restaurants;
                }
            }
        }
    }
}
