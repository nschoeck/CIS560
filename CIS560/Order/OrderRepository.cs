using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace CIS560
{
    class OrderRepository : IOrderRepository
    {
        SqlConnectionStringBuilder sqlBuilder = SqlBuilder.SqlConnectingStringBuilder;

        /// <summary>
        /// Creates an order in the database
        /// </summary>
        /// <param name="customerId">The ID of the <see cref="Customer"/> placing the order</param>
        /// <param name="driverId">The ID of the <see cref="Driver"/> delivering the order</param>
        /// <param name="addressId">The ID of the <see cref="Address"/> the order is being delivered to</param>
        /// <returns>The created <see cref="Order"/> if successful, otherwise null</returns>
        public Order CreateOrder(int customerId, int driverId, int addressId)
        {
            const string sqlCommandText = "CIS560.CreateOrder";

            try
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    using (SqlConnection connection = new SqlConnection(sqlBuilder.ConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand(sqlCommandText, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("CustomerID", customerId);
                            command.Parameters.AddWithValue("DriverID", driverId);
                            command.Parameters.AddWithValue("AddressID", addressId);

                            SqlParameter param = command.Parameters.Add("OrderID", SqlDbType.Int);
                            param.Direction = ParameterDirection.Output;

                            connection.Open();

                            command.ExecuteNonQuery();

                            transaction.Complete();

                            return new Order((int)param.Value, customerId, driverId, addressId);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not create order.  Exited with: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets an order from the database
        /// </summary>
        /// <param name="orderId">The ID of the order to get</param>
        /// <returns>An <see cref="Order"/> containing the information on the provided ID.  
        /// This will return null if no order was found containing the given <code>orderId</code>
        /// </returns>
        public Order GetOrder(int orderId)
        {
            //TODO: Set command
            string sqlCommandText = "CIS560.GetOrder";
            using (SqlConnection connection = new SqlConnection(sqlBuilder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlCommandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("OrderID", orderId);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (!reader.Read())
                    {
                        return null;
                    }

                    return new Order(
                        orderId,
                        reader.GetInt32(reader.GetOrdinal("CustomerID")),
                        reader.GetInt32(reader.GetOrdinal("DriverID")),
                        reader.GetInt32(reader.GetOrdinal("AddressID"))
                    );
                }
            }
        }

        /// <summary>
        /// Retrieves all orders from the database
        /// </summary>
        /// <returns>
        /// A <see cref="List{T}"/> of <see cref="Order"/> from the database. 
        /// This will return empty if no orders are found.
        /// </returns>
        public IReadOnlyList<Order> RetrieveOrders()
        {
            //TODO: Set command here
            string sqlCommandText = "CIS560.RetrieveOrders";
            using (SqlConnection connection = new SqlConnection(sqlBuilder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlCommandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    List<Order> orders = new List<Order>();

                    while (reader.Read())
                    {
                        orders.Add(new Order(
                            reader.GetInt32(reader.GetOrdinal("OrderID")),
                            reader.GetInt32(reader.GetOrdinal("CustomerID")),
                            reader.GetInt32(reader.GetOrdinal("DriverID")),
                            reader.GetInt32(reader.GetOrdinal("AddressID"))
                        ));
                    }

                    return orders;
                }
            }
        }
    }
}
