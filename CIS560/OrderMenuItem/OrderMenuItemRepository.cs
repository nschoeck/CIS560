using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace CIS560
{
    /// <summary>
    /// The repository for creating and getting <see cref="OrderMenuItem"/>
    /// </summary>
    class OrderMenuItemRepository : IOrderMenuItemRepository
    {
        SqlConnectionStringBuilder sqlBuilder = SqlBuilder.SqlConnectingStringBuilder;

        /// <summary>
        /// Creates an order menu item in the database
        /// </summary>
        /// <param name="orderId">The ID of the <see cref="Order"/></param>
        /// <param name="menuItemId">The ID of th <see cref="MenuItem"/></param>
        /// <param name="menuItemQuantity">The quantity purchased of the <see cref="MenuItem"/></param>
        /// <returns>
        /// An <see cref="OrderMenuItem"/> of the created order menu item, or null if the order menu item couldn't be created in the databse.
        /// </returns>
        public OrderMenuItem CreateOrderMenuItem(int orderId, int menuItemId, int menuItemQuantity)
        {
            const string sqlCommandText = "CIS560.CreateOrderMenuItem";

            try
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    using (SqlConnection connection = new SqlConnection(sqlBuilder.ConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand(sqlCommandText, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("OrderID", orderId);
                            command.Parameters.AddWithValue("MenuItemID", menuItemId);
                            command.Parameters.AddWithValue("MenuItemQuantity", menuItemQuantity);

                            connection.Open();

                            command.ExecuteNonQuery();

                            transaction.Complete();

                            return new OrderMenuItem(orderId, menuItemId, menuItemQuantity);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not create order menu item.  Exited with: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets an <see cref="OrderMenuItem"/> from the database
        /// </summary>
        /// <param name="orderId">The ID of the desired <see cref="Order"/></param>
        /// <param name="menuItemId">The ID of the desired <see cref="MenuItem"/></param>
        /// <returns>
        /// An <see cref="OrderMenuItem"/> containing the information of the <code>orderId</code> and <code>menuItemId</code> if found.
        /// If nothing corresponds to the given <code>orderId</code> and <code>menuItemId</code> this will return null.
        /// </returns>
        public OrderMenuItem GetOrderMenuItem(int orderId, int menuItemId)
        {
            //TODO: Set command
            string sqlCommandText = "CIS560.GetOrderMenuItem";
            using (SqlConnection connection = new SqlConnection(sqlBuilder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlCommandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("OrderID", orderId);
                    command.Parameters.AddWithValue("MenuItemID", menuItemId);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (!reader.Read())
                    {
                        return null;
                    }

                    return new OrderMenuItem(
                        orderId,
                        menuItemId,
                        reader.GetInt32(reader.GetOrdinal("MenuItemQuantity"))
                    );
                }
            }
        }

        /// <summary>
        /// Retrieves all <see cref="OrderMenuItem"/>s from the database.
        /// </summary>
        /// <returns>
        /// A <see cref="List{T}"/> of <see cref="OrderMenuItem"/>s found in the database.
        /// If none are found this will return an empty list.
        /// </returns>
        public IReadOnlyList<OrderMenuItem> RetrieveOrderMenuItems()
        {
            //TODO: Set command here
            string sqlCommandText = "CIS560.RetrieveOrderMenuItems";
            using (SqlConnection connection = new SqlConnection(sqlBuilder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlCommandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    List<OrderMenuItem> orderMenuItems = new List<OrderMenuItem>();

                    while (reader.Read())
                    {
                        orderMenuItems.Add(new OrderMenuItem(
                            reader.GetInt32(reader.GetOrdinal("OrderID")),
                            reader.GetInt32(reader.GetOrdinal("MenuItemID")),
                            reader.GetInt32(reader.GetOrdinal("MenuItemQuantity"))
                        ));
                    }

                    return orderMenuItems;
                }
            }
        }
    }
}
