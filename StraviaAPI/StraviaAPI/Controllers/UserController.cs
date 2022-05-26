using Microsoft.AspNetCore.Mvc;
using StraviaAPI.Data;

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
        public Task<String> Get() 
            => _SqlDb.GetUsers();

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public String Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] String value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] String value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
