using WorkBase.API.EC;
using WorkBase.Library.DTO;
using WorkBase.Library.Models;
using WorkBase.Library.Utilities;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace WorkBase.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<UserDTO> Get()
        {
            return new UserEC().Search();
        }

        [HttpGet("{id}")]
        public UserDTO? Get(int id)
        {
            return new UserEC().Get(id);
        }

        [HttpDelete("Delete/{id}")]
        public UserDTO? DeleteUser(int id)
        {
            return new UserEC().Delete(id);
        }

        [HttpPost]
        public User AddOrUpdate([FromBody] User user)
        {
            return new UserEC().AddOrUpdate(user);
        }

        [HttpPost("Search")]
        public IEnumerable<UserDTO> Search([FromBody] QueryMessage query)
        {
            return new UserEC().Search(query.Query);
        }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate(UserCredentials credentials)
        {
            var user = new UserEC().Authenticate(credentials.EmailAddress, credentials.Password);
            if (user != null)
            {
                return Ok(new UserDTO(user));
            }
            return BadRequest("Invalid email or password!");
        }


    }
}
