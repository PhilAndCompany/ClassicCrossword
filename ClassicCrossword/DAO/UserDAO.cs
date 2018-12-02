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

        public void Insert(Player player)
        {
            try
            {
                SqlConnection sqlConnection = Connect();
                string sql = string.Format("Insert into Player (login, pass) Values ('{0}', '{1}');", player.Login, player.Pass);

                using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
                {
                    cmd.ExecuteNonQuery();
                }
                Disconnect(sqlConnection);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public User GetUserByAuthorization(string login, string password)
        {
            User user = null;
            try
            {
                SqlConnection sqlConnection = Connect();
                string sql = string.Format("Select login, pass From Player Where login= Lower('{0}') AND pass='{1}'", login.ToLower(), password);


                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandText = sql;
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    user = new Player(dataReader[0].ToString(), dataReader[1].ToString());
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
