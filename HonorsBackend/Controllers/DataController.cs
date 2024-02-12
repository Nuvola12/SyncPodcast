using HonorsBackend.DataAccess;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HonorsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        DataDB db = DataDB.GetInstance();

        // GET: api/<DataController>
        [HttpGet("all")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /*
        // GET api/<DataController>/
        [HttpGet]
        public IActionResult Get([FromBody] string APIKey)
        {
            return Ok(db.GetDataByUUID(APIKey));
        }*/

        // GET api/<DataController>
        [HttpGet("{APIKey}")]
        public IActionResult Get(string APIKey)
        {
            return Ok(db.GetDataByUUID(APIKey));
        }

        // POST api/<DataController>
        [HttpPost]
        public IActionResult Post([FromBody] DataInput dataInput)
        {
            db.AddData(dataInput.APIKey,dataInput.LibraryData);
            return Ok();
        }

       
        // DELETE api/<DataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
