using Microsoft.AspNetCore.Mvc;
using StraviaAPI.Data;
using StraviaAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SportController : ControllerBase
    {
        private readonly SQLDB _SqlDb;

        public SportController(SQLDB sqlDb)
        {
            _SqlDb = sqlDb;
        }

        // GET: <SportController>
        [HttpGet]
        public Task<IEnumerable<Sport>> Get() 
            => _SqlDb.GetSports();
    }
}
