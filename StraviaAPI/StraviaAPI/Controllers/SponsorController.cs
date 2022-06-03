using Microsoft.AspNetCore.Mvc;
using StraviaAPI.Data;
using StraviaAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SponsorController : ControllerBase
    {
        private readonly SQLDB _SqlDb;

        public SponsorController(SQLDB sqlDb)
        {
            _SqlDb = sqlDb;
        }

        // GET: <SponsorController>
        [HttpGet]
        public Task<IEnumerable<Sponsor>> Get() 
            => _SqlDb.GetSponsors();

        // GET: <SponsorController>/{tradename}
        [HttpGet("{tradename}")]
        public Task<IEnumerable<Sponsor>> Get(String tradename)
            => _SqlDb.GetSponsor(tradename);
    }
}
