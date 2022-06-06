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
            String? queryString = null;

            if (activity.NoChallenge.Equals(0))
            {
                queryString = 
                        $"INSERT INTO [dbo].[Activity] ([sport], [no_race], [no_challenge], [o_username], [distance], [height], [a_date], [u_username], [gpx_id])" +
                        $"VALUES ('{activity.Type}', NULL, NULL, NULL, {activity.Distance}, {activity.Altitude}, '{activity.Date}', '{activity.Username}');" +
                        $"INSERT INTO [dbo].[Result] (no_activity, u_username, duration)" +
                        $"VALUES ((SELECT TOP (1) [no_activity] FROM [dbo].[Activity] ORDER BY [no_activity] DESC), '{activity.Username}', {activity.Duration}, {activity.Route});";
            }
            return queryString ?? throw new Exception("Not found!!");
        }

        public static User ToUser (this SqlDataReader reader)
        {
            return new User
            {
                Name = reader[0].ToString(),
                Lastname = reader[1].ToString(),
                Nationality = reader[2].ToString(),
                Birthdate = reader[3].ToString().Split(" ").ToList()[0],
                Category = reader[4].ToString(),
                Username = reader[5].ToString(),
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
                Name = reader[0].ToString(),
            };
        }

        public static Category ToCategory(this SqlDataReader reader)
        {
            return new Category
            {
                Name = reader[0].ToString(),
                Description = reader[1].ToString(),
            };
        }

        public static Sponsor ToSponsor(this SqlDataReader reader)
        {
            return new Sponsor
            {
                Tradename = reader[0].ToString(),
                Phone = int.Parse(reader[1].ToString()),
                Ceo = reader[2].ToString(),
                Logo = reader[3].ToString(),
            };
        }

        public static Race ToRace(this SqlDataReader reader)
        {
            return new Race
            {
                Name = reader[0].ToString(),
                NoRace = int.Parse(reader[1].ToString()),
                Type = reader[2].ToString(),
                Price = int.Parse(reader[3].ToString()),
                Date = reader[4].ToString().Split(" ").ToList()[0],
                Time = reader[4].ToString().Split(" ").ToList()[1].Remove(5),
                Route = int.Parse(reader[5].ToString())
            };
        }
        
        public static Challenge ToChallenge(this SqlDataReader reader)
        {
            return new Challenge
            {
                Cname = reader[0].ToString(),
                NoChallenge = int.Parse(reader[1].ToString()),
                FinalDate = reader[2].ToString().Split(" ").ToList()[0],
            };
        }

        public static ChallengeUser ToChallengeUser(this SqlDataReader reader)
        {
            return new ChallengeUser
            {
                Cname = reader[0].ToString(),
                NoChallenge = int.Parse(reader[1].ToString()),
                FinalDate = reader[2].ToString().Split(" ").ToList()[0],
            };
        }

        public static Group ToGroup(this SqlDataReader reader)
        {
            return new Group
            {
                Gname = reader[0].ToString(),
                NoGroup = int.Parse(reader[1].ToString()),
            };
        }

        public static Inscription ToInscription(this SqlDataReader reader)
        {
            return new Inscription
            {
                RaceName = reader[0].ToString(),
                NoRace = int.Parse(reader[1].ToString()),
                NoInscription = int.Parse(reader[2].ToString()),
                User = reader[3].ToString(),
                Type = reader[4].ToString(),
                Date = reader[5].ToString().Split(" ").ToList()[0],
                Voucher = reader[6].ToString(),
            };
        }

        public static ActivityReply ToActivityDetails(this SqlDataReader reader)
        {
            return new ActivityReply
            {
                Type = reader[0].ToString(),
                Distance = int.Parse(reader[1].ToString()),
                Altitude = int.Parse(reader[2].ToString()),
            };
        }

        public static ActivityDB ToActivityDB(this SqlDataReader reader)
        {
            return new ActivityDB
            {
                Name = reader[0].ToString(),
                Lastname = reader[1].ToString(),
                noactivity = int.Parse(reader[2].ToString()),
                Type = reader[3].ToString(),
                Gpx = int.Parse(reader[4].ToString()),
                Distance = int.Parse(reader[5].ToString()),
                Altitude = int.Parse(reader[6].ToString()),
                Date = reader[7].ToString().Split(" ").ToList()[0],
                Time = reader[7].ToString().Split(" ").ToList()[1].Remove(5),
                Image = reader[8].ToString(),
                Duration = int.Parse(reader[9].ToString()),
            };
        }

        public static RaceInscripted ToRaceInscripted(this SqlDataReader reader)
        {
            return new RaceInscripted
            {
                name = reader[0].ToString(),
                norace = int.Parse(reader[1].ToString()),
                noinscription = int.Parse(reader[2].ToString()),
                type = reader[3].ToString(),
                date = reader[4].ToString().Split(" ").ToList()[0],
                route = int.Parse(reader[5].ToString()),
            };
        }
    }
}
