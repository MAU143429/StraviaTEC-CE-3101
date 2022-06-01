using StraviaAPI.Models;

namespace StraviaAPI.Loaders
{
    public static class Extensions
    {
        public static String ToPostQuery (this User user)
        {
            return $"INSERT INTO [dbo].[User] (u_username, category, name, last_name, birthdate, nationality, u_password, image) VALUES ('{user.username}', '{user.category}', '{user.name}', '{user.last_name}', '{user.birthdate}', '{user.nationality}', '{user.password}', '{user.image}');";
        }
    }
}
