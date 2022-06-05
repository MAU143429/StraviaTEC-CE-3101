using Microsoft.AspNetCore.Mvc;
using System.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        // GET: <RouteController>
        [HttpGet]
        public Task<IFormFile> Get()
        {
            //IFormFile Route;
            String fileName = "route3.gpx";
            String filePath = Path.Combine("Routes", fileName);
            Directory.CreateDirectory("Routes");
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                //Route.CopyToAsync(fileStream);
            }
            FileStream fs = new FileStream("", FileMode.Create);
            

            return new string[] { "value1", "value2" };
        }
    }
}
