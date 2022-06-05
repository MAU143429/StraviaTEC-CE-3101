using Microsoft.AspNetCore.Mvc;
using StraviaAPI.Data;
using StraviaAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly SQLDB _SqlDb;

        public RaceController(SQLDB sqlDb)
        {
            _SqlDb = sqlDb;
        }

        // GET: api/<RaceController>
        [HttpGet]
        public Task<IEnumerable<Race>> GetRaces() 
            => _SqlDb.GetAllRaces();

        // GET <RaceController>/organizer/{username}
        [HttpGet("organizer/{username}")]
        public Task<IEnumerable<Race>> GetRacesO(String username) 
            => _SqlDb.GetRacesOrganizer(username);

        // GET <RaceController>user/{username}
        [HttpGet("user/{username}")]
        public Task<IEnumerable<Race>> GetRacesU(String username) 
            => _SqlDb.GetRacesUser(username);

        // POST <RaceController>
        [HttpPost]
        public Task Post(RaceInput input)
        {
            List<String> categories = input.Categories.Split("/").ToList();
            for (int i = 0; i < categories.Count; i++)
            {
                if (categories[i] == "") categories.RemoveAt(i);
            }
            List<String> sponsors = input.Sponsors.Split("/").ToList();
            for (int i = 0; i < sponsors.Count; i++)
            {
                if (sponsors[i] == "") sponsors.RemoveAt(i);
            }
            List<String> bankAcounts = input.Bank_Accounts.Split("/").ToList();
            for (int i = 0; i < bankAcounts.Count; i++)
            {
                if (bankAcounts[i] == "") bankAcounts.RemoveAt(i);
            }

            return _SqlDb.CreateRace(input, categories, sponsors, bankAcounts);
        }
    }
}
