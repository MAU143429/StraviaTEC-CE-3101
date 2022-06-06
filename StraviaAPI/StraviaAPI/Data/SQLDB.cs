using Microsoft.AspNetCore.Mvc;
using StraviaAPI.Loaders;
using StraviaAPI.Models;
using System.Data.SqlClient;
using System.Text;

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
            String queryString =
                $"SELECT [name], [last_name], [nationality], [birthdate], [category], [u_username], [u_password], [image] " +
                $"FROM [dbo].[User];";

            List<User>? result = new List<User>();

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader readerUser = command.ExecuteReader())
            {
                while (readerUser.Read())
                {
                    result.Add(readerUser.ToUser());
                }
            }
            await _Connection.CloseAsync();

            for (int i = 0; i < result.Count; i++)
            {
                int activities = 0;
                int age = 0;
                int followers = 0;
                int following = 0;
                String queryTemp;
                SqlCommand commandTemp;

                await _Connection.OpenAsync();
                queryTemp =
                    $"DECLARE @result INT;" +
                    $"EXECUTE @result = [dbo].[CountUserActivities] '{result[i].Username}';";
                commandTemp = new SqlCommand(queryTemp, _Connection);
                using (SqlDataReader readerActivities = commandTemp.ExecuteReader())
                {
                    while (readerActivities.Read())
                    {
                        activities = int.Parse(readerActivities[0].ToString());
                    }
                }

                result[i].Activities = activities;
                await _Connection.CloseAsync();

                await _Connection.OpenAsync();
                queryTemp =
                    $"DECLARE @result INT;" +
                    $"EXECUTE @result = [dbo].[GetAge] '{result[i].Username}';";
                commandTemp = new SqlCommand(queryTemp, _Connection);
                using (SqlDataReader readerAge = commandTemp.ExecuteReader())
                {
                    while (readerAge.Read())
                    {
                        age = int.Parse(readerAge[0].ToString());
                    }
                }

                result[i].Age = age;
                await _Connection.CloseAsync();
            }

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
            String queryString =
                $"SELECT [name], [last_name], [nationality], [birthdate], [category], [u_username], [u_password], [image]" +
                $"FROM [dbo].[User]" +
                $"WHERE [u_username] = '{username}';";

            List<User>? result = new List<User>();

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader readerUser = command.ExecuteReader())
            {
                while (readerUser.Read())
                {
                    result.Add(readerUser.ToUser());
                }
            }
            await _Connection.CloseAsync();

            for (int i = 0; i < result.Count; i++)
            {
                int activities = 0;
                int age = 0;
                int followers = 0;
                int following = 0;
                String queryTemp;
                SqlCommand commandTemp;

                await _Connection.OpenAsync();
                queryTemp =
                    $"DECLARE @result INT;" +
                    $"EXECUTE @result = [dbo].[CountUserActivities] '{result[i].Username}';";
                commandTemp = new SqlCommand(queryTemp, _Connection);
                using (SqlDataReader readerActivities = commandTemp.ExecuteReader())
                {
                    while (readerActivities.Read())
                    {
                        activities = int.Parse(readerActivities[0].ToString());
                    }
                }

                result[i].Activities = activities;
                await _Connection.CloseAsync();

                await _Connection.OpenAsync();
                queryTemp =
                    $"DECLARE @result INT;" +
                    $"EXECUTE @result = [dbo].[GetAge] '{result[i].Username}';";
                commandTemp = new SqlCommand(queryTemp, _Connection);
                using (SqlDataReader readerAge = commandTemp.ExecuteReader())
                {
                    while (readerAge.Read())
                    {
                        age = int.Parse(readerAge[0].ToString());
                    }
                }

                result[i].Age = age;
                await _Connection.CloseAsync();
            }

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
            String queryString =
                        $"INSERT INTO [dbo].[Activity] ([sport], [no_race], [no_challenge], [o_username], [distance], [height], [date], [u_username], [gpx_id])" +
                        $"VALUES ('{activity.Type}', NULL, NULL, NULL, {activity.Distance}, {activity.Altitude}, '{activity.Date}', '{activity.Username}', {activity.Route});" +
                        $"INSERT INTO [dbo].[Result] (no_activity, u_username, duration)" +
                        $"VALUES ((SELECT TOP (1) [no_activity] FROM [dbo].[Activity] ORDER BY [no_activity] DESC), '{activity.Username}', {activity.Duration});";
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
            String query = $"SELECT [no_challenge] FROM [dbo].[Activity] JOIN [dbo].[Result] ON [dbo].[Activity].[no_activity] = [dbo].[Result].[no_activity] WHERE [dbo].[Activity].[u_username] = '{activity.Username}' AND [sport] = '{activity.Type}' AND [duration] = '{activity.Duration}' AND [date] = '{activity.Date}';";

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

        public async Task CreateRace(RaceInput input, List<String> categories, List<String> sponsors, List<String> bankAccounts)
        {
            int? no_race = null;
            String queryRace =
                    $"INSERT INTO [dbo].[Race] ([o_username], [r_name], [price]) OUTPUT INSERTED.[no_race]" +
                    $"VALUES ('{input.Username}', '{input.Name}', {input.Price});";

            SqlCommand command1 = new SqlCommand(queryRace, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command1.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        no_race = int.Parse(reader[0].ToString());
                    }
                    catch (Exception e)
                    {
                        no_race = null;
                    }
                }
            }
            await _Connection.CloseAsync();

            String queryActivity =
                    $"INSERT INTO [dbo].[Activity] ([sport], [no_race], [no_challenge], [o_username], [distance], [height], [date], [u_username], [gpx_id])" +
                    $"VALUES ('{input.Type}', {no_race}, NULL, '{input.Username}', {input.Distance}, {input.Altitude}, '{input.Date}', NULL, {input.Route});";

            SqlCommand command2 = new SqlCommand(queryActivity, _Connection);
            await _Connection.OpenAsync();
            try
            {
                command2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            await _Connection.CloseAsync();

            for (int i = 0; i < categories.Count; i++)
            {
                String queryTemp =
                    $"INSERT INTO [dbo].[RaceC] ([no_race], [category])" +
                    $"VALUES ({no_race}, '{categories[i]}')";
                SqlCommand commandTemp = new SqlCommand(queryTemp, _Connection);

                await _Connection.OpenAsync();
                try
                {
                    commandTemp.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                await _Connection.CloseAsync();
            }

            for (int i = 0; i < sponsors.Count; i++)
            {
                String queryTemp =
                    $"INSERT INTO [dbo].[Sponsorship] ([tradename], [no_race])" +
                    $"VALUES ('{sponsors[i]}', {no_race})";
                SqlCommand commandTemp = new SqlCommand(queryTemp, _Connection);

                await _Connection.OpenAsync();
                try
                {
                    commandTemp.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                await _Connection.CloseAsync();
            }

            for (int i = 0; i < sponsors.Count; i++)
            {
                String queryTemp =
                    $"INSERT INTO [dbo].[Account] ([no_race], [bank_account])" +
                    $"VALUES ({no_race}, '{bankAccounts[i]}')";
                SqlCommand commandTemp = new SqlCommand(queryTemp, _Connection);

                await _Connection.OpenAsync();
                try
                {
                    commandTemp.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                await _Connection.CloseAsync();
            }
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
            String queryString =
                $"SELECT [dbo].[Race].[r_name], [dbo].[Race].[no_race], [dbo].[Activity].[sport], [dbo].[Race].[price], [dbo].[Activity].[date], [dbo].[Activity].[gpx_id]" +
                $"FROM [dbo].[Race] JOIN [dbo].[Activity] ON [dbo].[Race].[no_race] = [dbo].[Activity].[no_race]" +
                $"WHERE [dbo].[Race].[o_username] = '{username}';";

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

        public async Task CreateChallenge(ChallengeInput input, List<ActivityOrganizer> activities)
        {
            int? no_challenge = null;
            String queryChallenge =
                $"INSERT INTO [dbo].[Challenge] ([o_username], [c_name], [final_date]) OUTPUT INSERTED.[no_challenge]" +
                $"VALUES ('{input.Username}', '{input.Name}', '{input.FinalDate}')";

            SqlCommand command = new SqlCommand(queryChallenge, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    no_challenge = int.Parse(reader[0].ToString());
                }
            }
            await _Connection.CloseAsync();

            for (int i = 0; i < activities.Count; i++)
            {
                String queryActivity =
                    $"INSERT INTO [dbo].[Activity] ([sport], [no_race], [no_challenge], [o_username], [distance], [height], [date], [u_username], [gpx_id])" +
                    $"VALUES ('{activities[i].Type}', NULL, {no_challenge}, '{input.Username}', {activities[i].Distance}, {activities[i].Altitude}, NULL, NULL, NULL)";

                SqlCommand commandTemp = new SqlCommand(queryActivity, _Connection);
                await _Connection.OpenAsync();
                try
                {
                    commandTemp.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                await _Connection.CloseAsync();
            }
        }

        public async Task<IEnumerable<Challenge>> GetAllChallengesUser(String username)
        {
            String queryString =
                $"SELECT [dbo].[Challenge].[c_name], [dbo].[Challenge].[no_challenge], [dbo].[Challenge].[final_date]" +
                $"FROM [dbo].[Participation] JOIN [dbo].[Challenge] ON [dbo].[Participation].[no_challenge] = [dbo].[Challenge].[no_challenge]" +
                $"WHERE [dbo].[Participation].[u_username] <> '{username}';";

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
            String queryString = $"SELECT [c_name], [no_challenge], [final_date] FROM [dbo].[Challenge] WHERE [o_username] = '{username}';";

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

            for (int i = 0; i < result.Count; i++)
            {
                String queryActivities =
                    $"DECLARE @Result INT;" +
                    $"EXECUTE @Result = [dbo].[CountChallengeActivities] {result[i].NoChallenge};";
                SqlCommand commandTemp = new SqlCommand(queryActivities, _Connection);
                await _Connection.OpenAsync();
                using (SqlDataReader reader = commandTemp.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result[i].Activities = int.Parse(reader[0].ToString());
                    }
                }
                await _Connection.CloseAsync();
            }
            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }

        public async Task<IEnumerable<ChallengeUser>> GetChallengesUser(String username)
        {
            String queryString =
                $"SELECT [dbo].[Challenge].[c_name], [dbo].[Challenge].[no_challenge], [dbo].[Challenge].[final_date]" +
                $"FROM [dbo].[Participation] JOIN [dbo].[Challenge] ON [dbo].[Participation].[no_challenge] = [dbo].[Challenge].[no_challenge]" +
                $"WHERE [dbo].[Participation].[u_username] = '{username}';";

            List<ChallengeUser> result = new List<ChallengeUser>();

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader.ToChallengeUser());
                }
            }
            await _Connection.CloseAsync();

            for (int i = 0; i < result.Count; i++)
            {
                String queryTemp;
                SqlCommand commandTemp;

                queryTemp =
                    $"DECLARE @Result INT;" +
                    $"EXECUTE @Result = [dbo].[CountChallengeActivities] {result[i].NoChallenge};";
                commandTemp = new SqlCommand(queryTemp, _Connection);
                await _Connection.OpenAsync();
                using (SqlDataReader reader = commandTemp.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result[i].Activities = int.Parse(reader[0].ToString());
                    }
                }
                await _Connection.CloseAsync();

                queryTemp =
                    $"DECLARE @Result INT;" +
                    $"EXECUTE @Result = [dbo].[CompletedChallenge] {username}, {result[i].NoChallenge};";
                commandTemp = new SqlCommand(queryTemp, _Connection);
                await _Connection.OpenAsync();
                using (SqlDataReader reader = commandTemp.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result[i].Completed = int.Parse(reader[0].ToString());
                    }
                }
                await _Connection.CloseAsync();
                try
                {
                    result[i].Avg = result[i].Completed * 100 / result[i].Activities;
                }
                catch
                {
                    result[i].Avg = 0;
                }
            }

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

        public async Task<IEnumerable<Group>> GetGroupsUser(String username)
        {
            String queryString =
                $"SELECT [dbo].[Group].[g_name], [dbo].[Group].[no_group]" +
                $"FROM [dbo].[Member] JOIN [dbo].[Group] ON [dbo].[Member].[no_group] = [dbo].[Group].[no_group]" +
                $"WHERE [dbo].[Member].[u_username] = '{username}';";

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

            for (int i = 0; i < result.Count; i++)
            {
                String queryTemp =
                    $"DECLARE @Result INT;" +
                    $"EXECUTE @Result = [dbo].[GetMembers] {result[i].NoGroup};";
                SqlCommand commandTemp = new SqlCommand(queryTemp, _Connection);

                await _Connection.OpenAsync();
                using (SqlDataReader reader = commandTemp.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result[i].Members = int.Parse(reader[0].ToString());
                    }
                }
                await _Connection.CloseAsync();
            }

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }

        public async Task<IEnumerable<Group>> GetGroupsOrganizer(String username)
        {
            String queryString =
                $"SELECT [dbo].[Group].[g_name], [dbo].[Group].[no_group]" +
                $"FROM [dbo].[Group]" +
                $"WHERE [dbo].[Group].[o_username] = '{username}';";

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

            for (int i = 0; i < result.Count; i++)
            {
                String queryTemp =
                    $"DECLARE @Result INT;" +
                    $"EXECUTE @Result = [dbo].[GetMembers] {result[i].NoGroup};";
                SqlCommand commandTemp = new SqlCommand(queryTemp, _Connection);

                await _Connection.OpenAsync();
                using (SqlDataReader reader = commandTemp.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result[i].Members = int.Parse(reader[0].ToString());
                    }
                }
                await _Connection.CloseAsync();
            }

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }

        public async Task CreateGroup(GroupInput input)
        {
            String queryString = $"INSERT INTO [dbo].[Group] ([o_username], [g_name]) VALUES ('{input.Username}', '{input.Name}');";
            SqlCommand command = new SqlCommand(queryString, _Connection);
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

        public async Task<IActionResult> GetGpx(int id)
        {
            String queryString = $"SELECT [data] FROM [dbo].[Gpx] WHERE [gpx_id] = {id};";
            SqlCommand command = new SqlCommand(queryString, _Connection);

            Gpx? result = new Gpx();

            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = new Gpx
                    {
                        Id = id,
                        Data = Encoding.ASCII.GetBytes(reader[0].ToString()),
                    };
                }
            }
            await _Connection.CloseAsync();

            var file = new FileStreamResult(new MemoryStream(result.Data), "text/xml");

            return file ?? throw new Exception("Not found!!");
        }

        public async Task<int> CreateGpx(IFormFile data)
        {
            byte[] fileBytes;

            using (var stream = new MemoryStream())
            {
                await data.CopyToAsync(stream);
                fileBytes = stream.ToArray();
            }

            String queryString = $"INSERT INTO [dbo].[Gpx] ([data]) OUTPUT INSERTED.[gpx_id] VALUES ('{Encoding.Default.GetString(fileBytes)}');";
            SqlCommand command = new SqlCommand(queryString, _Connection);

            int result = 0;

            await _Connection.OpenAsync();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = int.Parse(reader[0].ToString());
                }
            }

            await _Connection.CloseAsync();

            return result;
        }

        public async Task<IEnumerable<Inscription>> GetOrganizerInscriptions(String username)
        {
            String queryString =
                $"SELECT [dbo].[Race].[r_name], [dbo].[Race].[no_race], [dbo].[Inscription].[no_inscription], [dbo].[Inscription].[u_username], [dbo].[Activity].[sport], [dbo].[Activity].[date], [dbo].[Inscription].[voucher]" +
                $"FROM [dbo].[Inscription] JOIN [dbo].[Race] ON [dbo].[Inscription].[no_race] = [dbo].[Race].[no_race] JOIN [dbo].[Activity] ON [dbo].[Race].[no_race] = [dbo].[Activity].[no_race]" +
                $"WHERE [dbo].[Race].[o_username] = '{username}' AND [dbo].[Inscription].[is_accepted] = 0;";
            SqlCommand command = new SqlCommand(queryString, _Connection);
            List<Inscription> result = new List<Inscription>();

            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader.ToInscription());
                }
            }
            await _Connection.CloseAsync();

            return result;
        }

        public async Task AcceptInscription(Acceptance inscription)
        {
            String queryString =
                $"UPDATE [dbo].[Inscription]" +
                $"SET [is_accepted] = 1" +
                $"WHERE [no_inscription] = {inscription.Id}";
            SqlCommand command = new SqlCommand(queryString, _Connection);

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

        public async Task<IEnumerable<ActivityReply>> GetChallengeActivities(int challenge)
        {
            String queryString =
                $"SELECT [dbo].[Activity].[sport], [dbo].[Activity].[distance], [dbo].[Activity].[height]" +
                $"FROM [dbo].[Activity]" +
                $"WHERE [dbo].[Activity].[no_challenge] = {challenge}";
            SqlCommand command = new SqlCommand(queryString, _Connection);

            List<ActivityReply> result = new List<ActivityReply>();

            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader.ToActivityDetails());
                }
            }
            await _Connection.CloseAsync();

            return result ?? throw new Exception("Not found!!");
        }

        public async Task<IEnumerable<ActivityDB>> GetAllActivitiesUser(String username)
        {
            String queryString = 
                $"SELECT [dbo].[User].[name], [dbo].[User].[last_name], [dbo].[Activity].[no_activity], [dbo].[Activity].[sport], [dbo].[Activity].[gpx_id], [dbo].[Activity].[distance], [dbo].[Activity].[height], [dbo].[Activity].[date], [dbo].[User].[image], [dbo].[Result].[duration]" +
                $"FROM [dbo].[User] JOIN [dbo].[Result] ON [dbo].[User].[u_username] = [dbo].[Result].[u_username] JOIN [dbo].[Activity] ON [dbo].[Result].[no_activity] = [dbo].[Activity].[no_activity]" +
                $"WHERE [dbo].[User].[u_username] = '{username}' AND [dbo].[Activity].[gpx_id] IS NOT NULL;";

            List<ActivityDB> result = new List<ActivityDB>();

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader.ToActivityDB());
                }
            }
            await _Connection.CloseAsync();

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }

        public async Task<IEnumerable<RaceInscripted>> GetInscriptedRaces(String username)
        {
            String queryString =
                $"SELECT [dbo].[Race].[r_name], [dbo].[Race].[no_race], [dbo].[Inscription].[no_inscription], [dbo].[Activity].[sport], [dbo].[Activity].[date], [dbo].[Activity].[gpx_id]" +
                $"FROM [dbo].[Inscription] JOIN [dbo].[Race] ON [dbo].[Inscription].[no_race] = [dbo].[Race].[no_race] JOIN [dbo].[Activity] ON [dbo].[Race].[no_race] = [dbo].[Activity].[no_race]" +
                $"WHERE [dbo].[Inscription].[u_username] = '{username}' AND [dbo].[Inscription].[is_accepted] = 1";

            List<RaceInscripted> result = new List<RaceInscripted>();

            SqlCommand command = new SqlCommand(queryString, _Connection);
            await _Connection.OpenAsync();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader.ToRaceInscripted());
                }
            }
            await _Connection.CloseAsync();

            if (result.Count.Equals(0)) result = null;

            return result ?? throw new Exception("Not found!!");
        }
    }
}
