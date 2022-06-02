using StraviaAPI.Models;
using System.Data.SqlClient;

namespace StraviaAPI.Loaders
{
    public static class Extensions
    {
        public static String ToPostQuery (this User user)
        {
            return $"INSERT INTO [dbo].[User] (u_username, category, name, last_name, birthdate, nationality, u_password, image) VALUES ('{user.Username}', '{user.Category}', '{user.Name}', '{user.Lastname}', '{user.Birthdate}', '{user.Nationality}', '{user.Password}', '{user.Image}');";
        }

        public static User ToUser (this SqlDataReader reader)
        {
            return new User
            {
                Username = reader[0].ToString(),
                Category = reader[1].ToString(),
                Name = reader[2].ToString(),
                Lastname = reader[3].ToString(),
                Birthdate = reader[4].ToString(),
                Nationality = reader[5].ToString(),
                Password = reader[6].ToString(),
                Image = reader[7].ToString(),
            };
        }

        public static Organizer ToOrganizer(this SqlDataReader reader)
        {
            return new Organizer
            {
                Username = reader[0].ToString(),
                Password = reader[1].ToString(),
            }
        }
    }
}
