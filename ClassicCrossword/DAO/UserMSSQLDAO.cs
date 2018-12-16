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
    public class UserMSSQLDAO : IUserDAO
    {

        public bool Insert(Player player)
        {
            try
            {
                if (!HasSameType(player, false))
                {
                    SqlConnection sqlConnection = Connect();
                    string sql = string.Format("Insert into Player (login, pass) Values (@player_login, @player_pass);");

                    using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
                    {
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@player_login";
                        param.Value = player.Login;
                        param.SqlDbType = SqlDbType.VarChar;
                        param.Size = 100;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@player_pass";
                        param.Value = player.Pass;
                        param.SqlDbType = SqlDbType.VarChar;
                        param.Size = 100;
                        cmd.Parameters.Add(param);

                        cmd.ExecuteNonQuery();
                    }
                    Disconnect(sqlConnection);
                    return true;
                }
                else return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool Update(Player player)
        {
            try
            {
                if (!HasSameType(player, true))
                {
                    SqlConnection sqlConnection = Connect();
                    string sql = "Update Player Set login=@player_login, pass=@player_pass  Where id=(@player_id);";

                    using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
                    {
                        SqlParameter param = new SqlParameter();
                        param = new SqlParameter();
                        param.ParameterName = "@player_id";
                        param.Value = player.Id;
                        param.SqlDbType = SqlDbType.Int;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@player_login";
                        param.Value = player.Login;
                        param.SqlDbType = SqlDbType.VarChar;
                        param.Size = 100;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@player_pass";
                        param.Value = player.Pass;
                        param.SqlDbType = SqlDbType.VarChar;
                        param.Size = 100;
                        cmd.Parameters.Add(param);

                        cmd.ExecuteNonQuery();
                    }
                    Disconnect(sqlConnection);
                    return true;
                }
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void DeleteById(int id)
        {
            try
            {
                SqlConnection sqlConnection = Connect();
                string sql = string.Format("Delete From Player Where id= '{0}'", id);
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                cmd.ExecuteNonQuery();
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

        private bool HasSameType(Player player, bool isUpdate)
        {
            try
            {
                SqlConnection sqlConnection = Connect();
                string sql = string.Format("Select count(id) From Player Where UPPER(REPLACE(login,' ',''))=UPPER(REPLACE('{0}',' ',''))", player.Login);
                if (isUpdate)
                    sql = string.Format("Select count(id) From Player Where UPPER(REPLACE(login,' ',''))=UPPER(REPLACE('{0}',' ','')) AND id!='{1}'", player.Login, player.Id);
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandText = sql;
                SqlDataReader dataReader = cmd.ExecuteReader();
                int count = -1;
                while (dataReader.Read())
                {
                    count = Convert.ToInt32(dataReader[0]);
                }
                dataReader.Close();
                Disconnect(sqlConnection);
                if (count > 0) return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        static SqlConnection Connect()
        {
            SqlConnection sqlConnection = null;
            try
            {
                string connectionString = @"Data Source=localhost;Initial Catalog=CrosswordDB;Integrated Security=True";
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
