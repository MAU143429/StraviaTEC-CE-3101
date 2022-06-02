using Microsoft.AspNetCore.Mvc;
using StraviaAPI.Data;
using StraviaAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrganizerController : ControllerBase
    {
        private readonly SQLDB _SqlDb;

        public OrganizerController (SQLDB sqlDb)
        {
            _SqlDb = sqlDb;
        }

        // GET <OrganizerController>/5
        [HttpGet("{username}")]
        public Task<IEnumerable<Organizer>> Get(String username)
            => _SqlDb.GetOrganizer(username);

        // POST: <UserController>/{username}/{password}
        [HttpPost("login")]
        public Task<Organizer> LoginUser(Login login)
            => _SqlDb.LoginOrganizer(login.Username, login.Password);
    }
}
