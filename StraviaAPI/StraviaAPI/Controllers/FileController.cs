using Microsoft.AspNetCore.Mvc;
using StraviaAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly SQLDB _SqlDb;

        public FileController(SQLDB sqlDb)
        {
            _SqlDb = sqlDb;
        }

        // GET <FileController>/{id}
        [HttpGet("{id}")]
        public Task<IActionResult> Get(int id)
        {
            return _SqlDb.GetGpx(id);
        }

        // POST <FileController>
        [HttpPost]
        public Task<int> CreateGpx(IFormFile data)
        {
            return _SqlDb.CreateGpx(data);
        }
    }
}
