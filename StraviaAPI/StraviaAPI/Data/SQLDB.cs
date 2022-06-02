using StraviaAPI.Loaders;
using StraviaAPI.Models;
using System.Data.SqlClient;

namespace StraviaAPI.Data
{
    public class SQLDB
    {
        private const String CONNECTION_STRING = "Server=tcp:stravia.database.windows.net,1433;Initial Catalog=StraviaDB;Persist Security Info=False;User ID=admin-stravia;Password=dbstrav1234!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private readonly SqlConnection _Connection;

        public SQLDB()
        {
            _Connection = new SqlConnection(CONNECTION_STRING);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            String queryString = "SELECT * FROM [dbo].[User];";

            List<User> result = new List<User>();

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader.ToUser());
                }
            }
            await _Connection.CloseAsync();

            return result ?? throw new Exception("Not found!!");
        }

        public async Task<IEnumerable<User>> GetUser(String username)
        {
            String queryString = $"SELECT * FROM [dbo].[User] WHERE u_username = '{username}';";

            List<User>? result = new List<User>();

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        result.Add(reader.ToUser());
                    }
                    catch (Exception e)
                    {
                        result = null;
                    }
                }
            }
            await _Connection.CloseAsync();

            return result ?? throw new Exception("Not found!!");
        }

        public async Task<IEnumerable<User>> Login (String username, String password)
        {
            String queryString = $"SELECT * FROM [dbo].[User] WHERE u_username = '{username}' AND u_password = '{password}';";

            List<User>? result = new List<User>();

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        result.Add(reader.ToUser());
                    }
                    catch (Exception e)
                    {
                        result = null;
                    }
                }
            }
            await _Connection.CloseAsync();

            return result ?? throw new Exception("Not found!!");
        }

        public async Task CreateUser(User value)
        {
            SqlCommand command = new SqlCommand(value.ToPostQuery(), _Connection);

            await _Connection.OpenAsync();

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            await _Connection.CloseAsync();
        }
    }
}
