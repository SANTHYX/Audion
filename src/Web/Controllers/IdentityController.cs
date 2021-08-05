using Application.Commons.Services;
using Application.Dto.Identity;
using Application.Dto.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Post([FromBody] LoginUserDto model)
        {
            await _service.LoginAsync(model);

            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] RegisterUserDto model)
        {
            await _service.RegisterAsync(model);

            return Ok();
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> Post([FromBody] RefreshTokenDto model)
        {
            await _service.RefreshToken(model);

            return Ok();
        }

        [HttpPut("revoke-token")]
        public async Task<IActionResult> Put([FromBody] RevokeTokenDto model)
        {
            await _service.RevokeTokenAsync(model);

            return Ok();
        }
    }
}
