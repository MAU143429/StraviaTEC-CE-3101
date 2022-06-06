using Microsoft.AspNetCore.Mvc;
using StraviaAPI.Data;
using StraviaAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly SQLDB _SqlDb;

        public ActivityController(SQLDB sqlDb)
        {
            _SqlDb = sqlDb;
        }

        // GET: <ActivityController>/user
        [HttpGet("user/{username}")]
        public Task<IEnumerable<ActivityDB>> GetActivities(String username)
            => _SqlDb.GetAllActivitiesUser(username);

        // POST: <ActivityController>/user
        [HttpPost("user")]
        public Task CreateActivity(ActivityUser activity) 
            => _SqlDb.CreateActivityUser(activity);

        // POST: <ActivityController>/reply
        [HttpPost("reply")]
        public IEnumerable<Reply> Reply(IEnumerable<Reply> reply)
            => reply;

        // POST: <ActivityController>/reply
        [HttpPost("reply/challenge")]
        public IEnumerable<ActivityReply> ReplyChallenge(IEnumerable<ActivityReply> reply)
            => reply;
    }
}
