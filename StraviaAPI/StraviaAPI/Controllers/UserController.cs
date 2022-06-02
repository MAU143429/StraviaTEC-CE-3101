using Microsoft.AspNetCore.Mvc;
using StraviaAPI.Data;
using StraviaAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SQLDB _SqlDb;

        public UserController(SQLDB sqlDb)
        {
            _SqlDb = sqlDb;
        }

        // GET: <UserController>
        [HttpGet]
        public Task<IEnumerable<User>> Get() 
            => _SqlDb.GetUsers();

        // GET: <UserController>/{username}
        [HttpGet("{username}")]
        public Task<IEnumerable<User>> Get(String username)
            => _SqlDb.GetUser(username);

        // POST: <UserController>/{username}/{password}
        [HttpPost("login")]
        public Task<User> Login(Login login)
            => _SqlDb.Login(login.Username, login.Password);

        // POST <UserController>
        [HttpPost]
        public void Post(User value) 
            => _SqlDb.CreateUser(value);
    }
}
