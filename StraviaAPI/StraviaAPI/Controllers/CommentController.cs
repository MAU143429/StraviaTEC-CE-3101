using Microsoft.AspNetCore.Mvc;
using StraviaAPI.Data;
using StraviaAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly Mongo _Database;

        public CommentController(Mongo database)
        {
            _Database = database;
        }

        // GET: <CommentController>
        [HttpGet]
        public async Task<IEnumerable<Comment>> Get() 
            => await _Database.GetComments();

        // GET <CommentController>/5
        [HttpGet("{id}")]
        public async Task<Comment> Get(String id) 
            => await _Database.FindComments(id);

        // POST <CommentController>
        [HttpPost]
        public async Task Post([FromBody] Comment value)
        {
            await _Database.AddComment(value);
        }

        // PUT <CommentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE <CommentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
