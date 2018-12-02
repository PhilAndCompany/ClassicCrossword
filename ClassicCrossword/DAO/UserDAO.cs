using ClassicCrossword.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCrossword.DAO
{
    public class UserDAO
    {
        public User GetUserByAuthorization(string login, string password)
        {
            User user = null;
            try
            {
                SqlConnection sqlConnection = Connect();
                string sql = string.Format("Select status From Uzer Where login= Lower('{0}') AND pass='{1}'", login.ToLower(), password);


                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandText = sql;
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    if (dataReader[0].ToString().Equals("admin"))
                        user = new Admin(login, password, dataReader[0].ToString());
                    else if (dataReader[0].ToString().Equals("player"))
                        user = new Player(login, password, dataReader[0].ToString());

                }
                dataReader.Close();
                Disconnect(sqlConnection);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return user;
        }

        static SqlConnection Connect()
        {
            SqlConnection sqlConnection = null;
            try
            {
                string connectionString = @"Data Source=VLAD;Initial Catalog=CrosswordDB;Integrated Security=True";
                sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sqlConnection;
        }

        static void Disconnect(SqlConnection sqlConnection)
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
