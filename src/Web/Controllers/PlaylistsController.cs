using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        // GET: api/<PlaylistsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PlaylistsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PlaylistsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PlaylistsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PlaylistsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
