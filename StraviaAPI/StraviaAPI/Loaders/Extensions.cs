using StraviaAPI.Models;
using System.Data.SqlClient;

namespace StraviaAPI.Loaders
{
    public static class Extensions
    {
        public static String ToPostQuery (this User user)
        {
            return $"INSERT INTO [dbo].[User] (u_username, category, name, last_name, birthdate, nationality, u_password, image) VALUES ('{user.username}', '{user.category}', '{user.name}', '{user.last_name}', '{user.birthdate}', '{user.nationality}', '{user.password}', '{user.image}');";
        }

        public static User ToUser (this SqlDataReader reader)
        {
            return new User
            {
                username = reader[0].ToString(),
                category = reader[1].ToString(),
                name = reader[2].ToString(),
                last_name = reader[3].ToString(),
                birthdate = reader[4].ToString(),
                nationality = reader[5].ToString(),
                password = reader[6].ToString(),
                image = reader[7].ToString(),
            };
        }
    }
}
