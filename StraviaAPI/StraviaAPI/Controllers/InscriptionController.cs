using Microsoft.AspNetCore.Mvc;
using StraviaAPI.Data;
using StraviaAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InscriptionController : ControllerBase
    {
        private readonly SQLDB _SqlDb;

        public InscriptionController(SQLDB sqlDb)
        {
            _SqlDb = sqlDb;
        }

        // GET api/<InscriptionController>/5
        [HttpGet("organizer/{username}")]
        public Task<IEnumerable<Inscription>> GetOrganizerInscriptions(String username) 
            => _SqlDb.GetOrganizerInscriptions(username);

        // POST api/<InscriptionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InscriptionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InscriptionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
