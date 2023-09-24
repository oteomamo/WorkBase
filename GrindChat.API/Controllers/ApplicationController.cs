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
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> _logger;

        public ApplicationController(ILogger<ApplicationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ApplicationDTO> Get()
        {
            return new ApplicationEC().Search();
        }

        [HttpGet("{id}")]
        public ApplicationDTO? Get(int id)
        {
            return new ApplicationEC().Get(id);
        }

        [HttpDelete("Delete/{id}")]
        public ApplicationDTO? DeleteApplication(int id)
        {
            return new ApplicationEC().Delete(id);
        }

        [HttpPost]
        public Application AddOrUpdate([FromBody] Application Application)
        {
            return new ApplicationEC().AddOrUpdate(Application);
        }

        [HttpPost("Search")]
        public IEnumerable<ApplicationDTO> Search([FromBody] QueryMessage query)
        {
            return new ApplicationEC().Search(query.Query);
        }
    }
}
