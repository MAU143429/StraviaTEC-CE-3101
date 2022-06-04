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

        /// <summary>
        /// Obtain a list of objects User
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }

        /// <summary>
        /// Obtain an object User by its username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }

        /// <summary>
        /// Obtain an object User by its username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<UserLog> LoginUser(String username, String password)
        {
            String queryString = $"SELECT * FROM [dbo].[User] WHERE u_username = '{username}' AND u_password = '{password}';";

            UserLog? result = null;

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        result = reader.ToLog();
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

        /// <summary>
        /// Obtain an object Organizer by its username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<Organizer>> GetOrganizer(String username)
        {
            String queryString = $"SELECT * FROM [dbo].[Organizer] WHERE o_username = '{username}';";

            List<Organizer>? result = new List<Organizer>();

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        result.Add(reader.ToOrganizer());
                    }
                    catch (Exception e)
                    {
                        result = null;
                    }
                }
            }
            await _Connection.CloseAsync();

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }

        /// <summary>
        /// Obtain an object Organizer by its username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<UserLog> LoginOrganizer(String username, String password)
        {
            String queryString = $"SELECT * FROM [dbo].[Organizer] WHERE o_username = '{username}' AND o_password = '{password}';";

            UserLog? result = null;

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        result = reader.ToLog();
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

        /// <summary>
        /// Creates an object User in the Database
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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

        public async Task CreateActivityUser(ActivityUser activity)
        {
            SqlCommand command = new SqlCommand(activity.ToPostQuery(), _Connection);

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

        public int GetNoActivityUser(ActivityUser activity)
        {
            String query = $"SELECT [no_challenge] FROM [dbo].[Activity] JOIN [dbo].[Result] ON [dbo].[Activity].[no_activity] = [dbo].[Result].[no_activity] WHERE [dbo].[Activity].[u_username] = '{activity.Username}' AND [sport] = '{activity.Type}' AND [duration] = '{activity.Duration}' AND [a_date] = '{activity.Date}';";

            SqlCommand command = new SqlCommand(query, _Connection);

            int? result = null;

            _Connection.OpenAsync();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = int.Parse(reader[0].ToString());
                }
            }

            _Connection.CloseAsync();

            return result ?? throw new Exception("Not found!!");
        }

        public async Task UpdateActivity(ActivityDB activity)
        {
            String query = 
                $"UPDATE [dbo].[Activity]" +
                $"SET [sport] = '{activity.Sport}'" +
                $"SET [no_race] = {activity.NoRace}" +
                $"SET [no_challenge] = {activity.NoChallenge}" +
                $"SET [o_username] = '{activity.Ousername}'" +
                $"SET [route] = '{activity.Route}'" +
                $"SET [distance] = {activity.Distance}" +
                $"SET [height] = {activity.Height}" +
                $"SET [a_date] = '{activity.Date}'" +
                $"SET [u_username] = '{activity.Uusername}'" +
                $"WHERE [no_activity] = {activity.NoActivity}";

            SqlCommand command = new SqlCommand(query, _Connection);

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

        /* 
        public async Task<int> GetChallengeActivities(int NoChallenge)
        {
            String queryString = $"";
        }
        */

        /// <summary>
        /// Obtain a list of objects Sport
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<Sport>> GetSports()
        {
            String queryString = $"SELECT * FROM [dbo].[Sport];";

            SqlCommand command = new SqlCommand(queryString, _Connection);

            List<Sport> result = new List<Sport>();

            await _Connection.OpenAsync();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader.ToSport());
                }
            }

            await _Connection.CloseAsync();

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }

        /// <summary>
        /// Obtain a list of objects Category
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<Category>> GetCategories()
        {
            String queryString = $"SELECT * FROM [dbo].[Category];";

            SqlCommand command = new SqlCommand(queryString, _Connection);

            List<Category> result = new List<Category>();

            await _Connection.OpenAsync();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader.ToCategory());
                }
            }

            await _Connection.CloseAsync();

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }

        public async Task<IEnumerable<Sport>> GetSport(String sport)
        {
            String queryString = $"SELECT * FROM [dbo].[Sport] WHERE sport = '{sport}';";

            List<Sport>? result = new List<Sport>();

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        result.Add(reader.ToSport());
                    }
                    catch (Exception e)
                    {
                        result = null;
                    }
                }
            }
            await _Connection.CloseAsync();

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }

        public async Task<IEnumerable<Sponsor>> GetSponsors()
        {
            String queryString = $"SELECT * FROM [dbo].[Sponsor];";

            SqlCommand command = new SqlCommand(queryString, _Connection);

            List<Sponsor> result = new List<Sponsor>();

            await _Connection.OpenAsync();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader.ToSponsor());
                }
            }

            await _Connection.CloseAsync();

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }

        public async Task<IEnumerable<Sponsor>> GetSponsor(String tradename)
        {
            String queryString = $"SELECT * FROM [dbo].[Sponsor] WHERE tradename = '{tradename}';";

            List<Sponsor>? result = new List<Sponsor>();

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        result.Add(reader.ToSponsor());
                    }
                    catch (Exception e)
                    {
                        result = null;
                    }
                }
            }
            await _Connection.CloseAsync();

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }

        public async Task<IEnumerable<Race>> GetAllRaces()
        {
            String queryString = $"SELECT * FROM [dbo].[Race];";

            List<Race> result = new List<Race>();

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader.ToRace());
                }
            }
            await _Connection.CloseAsync();

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }

        public async Task<IEnumerable<Race>> GetRacesOrganizer(String username)
        {
            String queryString = $"SELECT * FROM [dbo].[Race] WHERE o_username = '{username}';";

            List<Race> result = new List<Race>();

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader.ToRace());
                }
            }
            await _Connection.CloseAsync();

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }

        public async Task<IEnumerable<Race>> GetRacesUser(String username)
        {
            String queryString = 
                $"SELECT [no_inscription], [dbo].[Inscription].[no_race], [dbo].[Inscription].[u_username], [dbo].[Inscription].[voucher], [dbo].[Inscription].[is_accepted] " +
                $"FROM [dbo].[Race] JOIN [dbo].[Inscription]" +
                $"ON [dbo].[Race].[no_race] = [dbo].[Inscription].[no_race]" +
                $"WHERE [u_username] = '{username}';";

            List<Race> result = new List<Race>();

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader.ToRace());
                }
            }
            await _Connection.CloseAsync();

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }

        public async Task<IEnumerable<Challenge>> GetAllChallenges()
        {
            String queryString = $"";

            List<Challenge> result = new List<Challenge>();

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader.ToChallenge());
                }
            }
            await _Connection.CloseAsync();

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }

        public async Task<IEnumerable<Challenge>> GetChallengesOrganizer(String username)
        {
            String queryString = $"SELECT * FROM [dbo].[Challenge] WHERE [o_username] = '{username}';";

            List<Challenge> result = new List<Challenge>();

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader.ToChallenge());
                }
            }
            await _Connection.CloseAsync();

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }

        public async Task<IEnumerable<Challenge>> GetChallengesUser(String username)
        {
            String queryString = 
                $"SELECT * FROM [dbo].[Challenge]" +
                $"JOIN [dbo].[Participation] ON [dbo].[Challenge].[no_challenge] = [dbo].[Participation].[no_challenge]" +
                $"WHERE [u_username] = '{username}';";

            List<Challenge> result = new List<Challenge>();

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader.ToChallenge());
                }
            }
            await _Connection.CloseAsync();

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }

        public async Task<IEnumerable<Group>> GetAllGroups()
        {
            String queryString = $"SELECT * FROM [dbo].[Group];";

            List<Group> result = new List<Group>();

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader.ToGroup());
                }
            }
            await _Connection.CloseAsync();

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }

        public async Task<IEnumerable<Group>> GetGroup(String name)
        {
            String queryString = $"SELECT * FROM [dbo].[Group] WHERE [g_name] = '{name}';";

            List<Group> result = new List<Group>();

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader.ToGroup());
                }
            }
            await _Connection.CloseAsync();

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }
    }
}
