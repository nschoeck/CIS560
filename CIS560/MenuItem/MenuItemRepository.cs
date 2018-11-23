using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using System.Data.SqlClient;

namespace CIS560
{
    /// <summary>
    /// The repository for creating and getting menu items
    /// </summary>
    class MenuItemRepository : IMenuItemRepository
    {
        SqlConnectionStringBuilder sqlBuilder = SqlBuilder.SqlConnectingStringBuilder;

        /// <summary>
        /// Creates a menu item in the databse
        /// </summary>
        /// <param name="restaurantId">The ID of the restaurant this menu item belongs to</param>
        /// <param name="name">The name of the menu item</param>
        /// <param name="price">The cost of the menu item</param>
        /// <returns>A <see cref="MenuItem"/> containing the information provided, or null if the menu item couldn't be created</returns>
        public MenuItem CreateMenuItem(int restaurantId, string name, decimal price)
        {
            const string sqlCommandText = "CIS560.CreateMenuItem";

            try
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    using (SqlConnection connection = new SqlConnection(sqlBuilder.ConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand(sqlCommandText, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("RestaurantID", restaurantId);
                            command.Parameters.AddWithValue("Name", name);
                            command.Parameters.AddWithValue("Price", price);

                            SqlParameter param = command.Parameters.Add("MenuItemID", SqlDbType.Int);
                            param.Direction = ParameterDirection.Output;

                            connection.Open();

                            command.ExecuteNonQuery();

                            transaction.Complete();

                            return new MenuItem((int)param.Value, restaurantId, name, price);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not create menu item.  Exited with: {0}", e.Message);
                return null;
            }
        }


        /// <summary>
        /// Gets a menu item from the databse
        /// </summary>
        /// <param name="menuItemId">The ID of the desired menu item</param>
        /// <returns>
        /// A <see cref="MenuItem"/> with the information corresponding to the <code>menuItemId</code>.  
        /// This will be null if no menu item with the passed menuItemId exists.
        /// </returns>
        public MenuItem GetMenuItem(int menuItemId)
        {
            //TODO: Set command
            string sqlCommandText = "CIS560.GetMenuItem";
            using (SqlConnection connection = new SqlConnection(sqlBuilder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlCommandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("MenuItemID", menuItemId);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (!reader.Read())
                    {
                        return null;
                    }

                    return new MenuItem(
                        menuItemId,
                        reader.GetInt32(reader.GetOrdinal("RestaurantID")),
                        reader.GetString(reader.GetOrdinal("Name")),
                        reader.GetInt32(reader.GetOrdinal("Price"))
                    );
                }
            }
        }

        /// <summary>
        /// Gets all menu items from the database
        /// </summary>
        /// <returns>
        /// A <see cref="List{T}"/> of <see cref="MenuItem"/>.  This list may be empty if there are no menu items in the database.
        /// </returns>
        public IReadOnlyList<MenuItem> RetrieveMenuItems()
        {
            //TODO: Set command here
            string sqlCommandText = "CIS560.RetrieveMenuItems";
            using (SqlConnection connection = new SqlConnection(sqlBuilder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlCommandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    List<MenuItem> menuItems = new List<MenuItem>();

                    while (reader.Read())
                    {
                        menuItems.Add(new MenuItem(
                            reader.GetInt32(reader.GetOrdinal("MenuItemID")),
                            reader.GetInt32(reader.GetOrdinal("RestaurantID")),
                            reader.GetString(reader.GetOrdinal("Name")),
                            reader.GetInt32(reader.GetOrdinal("Price"))
                        ));
                    }

                    return menuItems;
                }
            }
        }
    }
}
