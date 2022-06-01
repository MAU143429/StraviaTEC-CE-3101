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

        public async void CreateUser(String username, String category, String name, String last_name, String birthdate, String nationality, String password, String image)
        {
            String queryString = "INSERT INTO dbo.User(u_username, category, name, last_name, birthdate, nationality, u_password, image) VALUES (@user, @cat, @name, @lname, @bd, @nat, @password, @img);";
            String? result = null;

            SqlCommand command = new SqlCommand(queryString, _Connection);
            command.Parameters.AddWithValue("@user", username);
            command.Parameters.AddWithValue("@cat", category);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@lname", last_name);
            command.Parameters.AddWithValue("@bd", birthdate);
            command.Parameters.AddWithValue("@nat", nationality);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@img", image);

            await _Connection.OpenAsync();
            command.ExecuteNonQuery();
            await _Connection.CloseAsync();
        }
    }
}
