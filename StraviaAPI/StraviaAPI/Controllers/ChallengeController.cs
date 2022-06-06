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
        [HttpGet("user/all/{username}")]
        public Task<IEnumerable<Challenge>> GetAllChallengesUser(String username) 
            => _SqlDb.GetAllChallengesUser(username);

        // GET: <ChallengeController>/{username}
        [HttpGet("organizer/{username}")]
        public Task<IEnumerable<Challenge>> GetChallengesOrganizer(String username) 
            => _SqlDb.GetChallengesOrganizer(username);

        // GET: <ChallengeController>/{username}
        [HttpGet("user/{username}")]
        public Task<IEnumerable<ChallengeUser>> GetChallengeUser(String username) 
            => _SqlDb.GetChallengesUser(username);

        // GET: <ChallengeController>/{username}
        [HttpGet("activities/{challenge}")]
        public Task<IEnumerable<ActivityReply>> GetChallengeActivities(int challenge)
            => _SqlDb.GetChallengeActivities(challenge);

        // POST <ChallengeController>
        [HttpPost]
        public Task Post(ChallengeInput input)
        {
            List<ActivityOrganizer> activities = new List<ActivityOrganizer>();
            List<String> stringActivities = input.Activities.Split("/").ToList();
            for (int i = 0; i < stringActivities.Count; i++)
            {
                if (stringActivities[i] == "") stringActivities.RemoveAt(i);
                else
                {
                    List<String> data = stringActivities[i].Split(";").ToList();
                    ActivityOrganizer activity = new ActivityOrganizer
                    {
                        Type = data[0],
                        Distance = int.Parse(data[1]),
                        Altitude = int.Parse(data[2]),
                    };
                    activities.Add(activity);
                }
            }

            return _SqlDb.CreateChallenge(input, activities);
        }
    }
}
