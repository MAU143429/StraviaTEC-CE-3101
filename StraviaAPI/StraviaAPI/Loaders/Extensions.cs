using StraviaAPI.Models;
using System.Data.SqlClient;

namespace StraviaAPI.Loaders
{
    public static class Extensions
    {
        public static String ToPostQuery (this User user)
        {
            return  $"INSERT INTO [dbo].[User] (u_username, category, name, last_name, birthdate, nationality, u_password, image) " +
                    $"VALUES ('{user.Username}', '{user.Category}', '{user.Name}', '{user.Lastname}', '{user.Birthdate}', '{user.Nationality}', '{user.Password}', '{user.Image}');";
        }

        public static String ToPostQuery(this ActivityUser activity)
        {
            String query = null;
            if (activity.NoChallenge.Equals(0))
            {
                query = $"INSERT INTO [dbo].[Activity] ([sport], [no_race], [no_challenge], [o_username], [route], [distance], [height], [a_date], [u_username])" +
                        $"VALUES ('{activity.Type}', NULL, NULL, NULL, '{activity.Route}', {activity.Distance}, {activity.Altitude}, '{activity.Date}', '{activity.Username}');" +
                        $"INSERT INTO [dbo].[Result] (no_activity, u_username, duration)" +
                        $"VALUES ((SELECT TOP (1) [no_activity] FROM [dbo].[Activity] ORDER BY [no_activity] DESC), '{activity.Username}', {activity.Duration});";
            }
            return query ?? throw new Exception("Not found!!");
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
            };
        }

        public static UserLog ToLog(this SqlDataReader reader)
        {
            return new UserLog
            {
                Username = reader[0].ToString(),
            };
        }

        public static Sport ToSport(this SqlDataReader reader)
        {
            return new Sport
            {
                sport = reader[0].ToString(),
            };
        }
    }
}
