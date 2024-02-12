using HonorsBackend.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HonorsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserDB uc = UserDB.GetInstance();

        // GET: api/<UserController>
        [HttpPost]
        public IActionResult Get([FromBody] UserCredentials credentials)
        {

            string x = uc.GetUUID(credentials.Username, credentials.Password);
            Debug.WriteLine(x);

            if (x == null)
            {
                return NotFound();
            }

            return Ok(x);
        }

        [HttpGet("all")]
        public IActionResult Get()
        { 
            return Ok(uc.GetAllUsers());
        }

        // POST api/<UserController>
        [HttpPost("create")]
        public IActionResult Post([FromBody] UserCredentials credentials)
        {
            

            var user = new User();
            user.Username = credentials.Username;
            user.Password = credentials.Password;
            Guid uuid = Guid.NewGuid();


            user.APIKey = uuid.ToString("N");
            uc.AddUser(user);

            return Ok("Account Created");

        }

        // PUT api/<UserController>/
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] string APIKey)
        {
            uc.DeleteByApiKey(APIKey);
            return Ok("User Deleted");

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
