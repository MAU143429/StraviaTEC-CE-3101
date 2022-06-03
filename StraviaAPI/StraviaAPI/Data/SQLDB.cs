﻿using StraviaAPI.Loaders;
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

        public async Task CreateActivityUser(ActivityUser value)
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

            return result ?? throw new Exception("Not found!!");
        }
    }
}
