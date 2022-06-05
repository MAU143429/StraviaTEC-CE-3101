using Microsoft.AspNetCore.Mvc;
using StraviaAPI.Data;
using StraviaAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly SQLDB _SqlDb;

        public ChallengeController(SQLDB sqlDb)
        {
            _SqlDb = sqlDb;
        }

        // GET: <ChallengeController>
        [HttpGet]
        public Task<IEnumerable<Challenge>> GetAllChallenges() 
            => _SqlDb.GetAllChallenges();

        // GET: <ChallengeController>/{username}
        [HttpGet("organizer/{username}")]
        public Task<IEnumerable<Challenge>> GetChallengesOrganizer(String username) 
            => _SqlDb.GetChallengesOrganizer(username);

        // GET: <ChallengeController>/{username}
        [HttpGet("user/{username}")]
        public Task<IEnumerable<Challenge>> GetChallengeUser(String username) 
            => _SqlDb.GetChallengesUser(username);

        // POST <ChallengeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
