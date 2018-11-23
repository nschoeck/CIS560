using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using System.Data;

namespace CIS560
{
    /// <summary>
    /// The repository for creating and getting customers in the database
    /// </summary>
    class CustomerRepository : ICustomerRepository
    {
        SqlConnectionStringBuilder sqlBuilder = SqlBuilder.SqlConnectingStringBuilder;

        /// <summary>
        /// Gets all customers in the database
        /// </summary>
        /// <returns>
        /// A <see cref="List{T}"/> of every <see cref="Customer"/> in the database, or an empty list if none are found
        /// </returns>
        public Customer CreateCustomer(string firstName, string lastName, int primaryAddressId, string email, int phoneNumber)
        {
            const string sqlCommandText = "CIS560.CreateCustomer";

            try
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    using (SqlConnection connection = new SqlConnection(sqlBuilder.ConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand(sqlCommandText, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("FirstName", firstName);
                            command.Parameters.AddWithValue("LastName", lastName);
                            command.Parameters.AddWithValue("PrimaryAddressID", primaryAddressId);
                            command.Parameters.AddWithValue("Email", email);
                            command.Parameters.AddWithValue("PhoneNumber", phoneNumber);

                            SqlParameter param = command.Parameters.Add("CustomerID", SqlDbType.Int);
                            param.Direction = ParameterDirection.Output;

                            connection.Open();

                            command.ExecuteNonQuery();

                            transaction.Complete();

                            return new Customer((int)param.Value, firstName, lastName, primaryAddressId, email, phoneNumber);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Could not create customer.  Exited with: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets a <see cref="Customer"/> from the table.
        /// </summary>
        /// <param name="customerId">The ID of the desired <see cref="Customer"/></param>
        /// <returns>
        /// The <see cref="Customer"/> containing the <code>customerId</code>, or <code>null</code> if there is none
        /// </returns>
        public Customer GetCustomer(int customerId)
        {
            //TODO: Set command
            string sqlCommandText = "CIS560.GetCustomer";
            using (SqlConnection connection = new SqlConnection(sqlBuilder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlCommandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("CustomerID", customerId);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (!reader.Read())
                    {
                        return null;
                    }

                    return new Customer(
                        customerId,
                        reader.GetString(reader.GetOrdinal("FirstName")),
                        reader.GetString(reader.GetOrdinal("LastName")),
                        reader.GetInt32(reader.GetOrdinal("PrimaryAddressID")),
                        reader.GetString(reader.GetOrdinal("Email")),
                        reader.GetInt32(reader.GetOrdinal("PhoneNumber"))
                    );
                }
            }
        }

        /// <summary>
        /// Gets all customers in the database
        /// </summary>
        /// <returns>
        /// A <see cref="List{T}"/> of every <see cref="Customer"/> in the database, or an empty list if none are found
        /// </returns>
        public IReadOnlyList<Customer> RetrieveCustomers()
        {
            //TODO: Set command here
            string sqlCommandText = "CIS560.RetrieveCustomers";
            using (SqlConnection connection = new SqlConnection(sqlBuilder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlCommandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    List<Customer> customers = new List<Customer>();

                    while (reader.Read())
                    {
                        customers.Add(new Customer(
                            reader.GetInt32(reader.GetOrdinal("CustomerID")),
                            reader.GetString(reader.GetOrdinal("FirstName")),
                            reader.GetString(reader.GetOrdinal("LastName")),
                            reader.GetInt32(reader.GetOrdinal("PrimaryAddressID")),
                            reader.GetString(reader.GetOrdinal("Email")),
                            reader.GetInt32(reader.GetOrdinal("PhoneNumber"))
                        ));
                    }

                    return customers;
                }
            }
        }
    }
}
