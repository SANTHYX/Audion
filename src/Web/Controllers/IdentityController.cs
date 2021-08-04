using Application.Commons.Services;
using Application.Dto.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {      
        private readonly IIdentityService _service;

        public IdentityController(IIdentityService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody] LoginUserModel model)
        {
            await _service.LoginAsync(model);

            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] RegisterUserModel model)
        {
            await _service.RegisterAsync(model);

            return Ok();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
