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

        // POST: <ActivityController>/user
        [HttpPost("user")]
        public Task CreateActivity(ActivityUser activity)
        {
            return _SqlDb.CreateActivityUser(activity);
        }

        // POST: <ActivityController>/reply
        [HttpPost("reply")]
        public IEnumerable<Reply> Reply(IEnumerable<Reply> reply)
            => reply;
    }
}
