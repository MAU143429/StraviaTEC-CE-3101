using Microsoft.AspNetCore.Mvc;
using StraviaAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaAPI.Models
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly SQLDB _SqlDb;

        public CategoryController(SQLDB sqlDb)
        {
            _SqlDb = sqlDb;
        }

        // GET: <CategoryController>
        [HttpGet]
        public Task<IEnumerable<Category>> Get()
            => _SqlDb.GetCategories();
    }
}
