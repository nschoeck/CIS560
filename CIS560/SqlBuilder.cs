using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CIS560
{
    /// <summary>
    /// Static class containing a <see cref="SqlConnectionStringBuilder"/> which holds the information for connecting to the databse
    /// </summary>
    static class SqlBuilder
    {
        public static readonly SqlConnectionStringBuilder SqlConnectingStringBuilder;

        static SqlBuilder()
        {
            SqlConnectingStringBuilder = new SqlConnectionStringBuilder();
            SqlConnectingStringBuilder.DataSource = "cis560g9.database.windows.net";
            SqlConnectingStringBuilder.UserID = "cis560g9";
            SqlConnectingStringBuilder.Password = "Hi123321!";
            SqlConnectingStringBuilder.InitialCatalog = "CIS560";
        }
    }
}
