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

        public async Task<String> GetUsers()
        {
            String queryString = "SELECT * FROM dbo.Persons;";

            String? result = null;

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = String.Format("{0}, {1}", reader[0], reader[1]);
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
