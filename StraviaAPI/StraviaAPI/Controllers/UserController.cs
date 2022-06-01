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

        // GET: <UserController>/Get
        [HttpGet("Get")]
        public Task<String> Get() 
            => _SqlDb.GetUsers();

        // POST <UserController>/Add
        [HttpPost("Add")]
        public void Post([FromBody] User value) 
            => _SqlDb.CreateUser(value.username, value.category, value.name, value.last_name, value.birthdate, value.nationality, value.password, value.image);
    }
}
