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

        /// <summary>
        /// Endpoint handling user authentication.
        /// If he pass proccess sucesfully, controller will return access token. 
        /// </summary>
        /// <param name="model">Object contains user creedentials</param>
        /// <returns>Access token and metadata</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody] LoginUserDto model)
        {
            await _service.LoginAsync(model);

            return Ok();
        }

        /// <summary>
        /// Endpoint handling registering user in system
        /// </summary>
        /// <param name="model">Informations required to create user instance</param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] RegisterUserDto model)
        {
            await _service.RegisterAsync(model);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Access token and metadata</returns>
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
