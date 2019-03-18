using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCrossword.DAO
{
    static class ConnectionDB
    {
        public static SqlConnection Connect()
        {
            SqlConnection sqlConnection = null;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CrosswordDBConnectionString"].ConnectionString;
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sqlConnection;
        }

        public static void Disconnect(SqlConnection sqlConnection)
        {
            try
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
