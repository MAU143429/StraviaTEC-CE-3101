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
            _SqlDb.CreateActivityUser(activity);
            int NoAct = _SqlDb.GetNoActivityUser(activity);

            String fileName = "";
            String filePath = "";
            fileName = Path.GetFileName(activity.Route.FileName);
            filePath = Path.Combine("Rcs\\Routes", NoAct.ToString(), fileName);
            Directory.CreateDirectory("Rcs\\Routes\\" + NoAct.ToString());
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                activity.Route.CopyToAsync(fileStream);
            }

            return _SqlDb.UpdateActivity(new ActivityDB
            {
                NoActivity = NoAct,
                Sport = activity.Type,
                NoRace = null,
                NoChallenge = null,
                Ousername = null,
                Route = filePath,
                Distance = activity.Distance,
                Height = activity.Altitude,
                Date = activity.Date,
                Uusername = activity.Username
            });
        }

        // POST: <ActivityController>/reply
        [HttpPost("reply")]
        public IEnumerable<Reply> Reply(IEnumerable<Reply> reply)
            => reply;
    }
}
