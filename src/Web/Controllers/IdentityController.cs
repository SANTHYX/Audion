using Application.Commons.Services;
using Application.Dto.Identity;
using Application.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDto model)
        {
            var token = await _service.LoginAsync(model);

            return Ok(token);
        }

        /// <summary>
        /// Endpoint handling registration user instance to system 
        /// </summary>
        /// <param name="model">Informations required to create user instance</param>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserDto model)
        {
            await _service.RegisterAsync(model);

            return Ok();
        }

        /// <summary>
        /// Endpoint handling generation of new access tokens for sign-in users after expire
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Object wit access token and metadata</returns>
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenDto model)
        {
            var refreshToken = await _service.RefreshToken(model);

            return Ok(refreshToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("recovery-password")]
        public async Task<IActionResult> RecoveryPasswordAsync([FromBody] string email)
        {
            await _service.CreateRecoveryPasswordThreadAsync(email);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recoveryId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("recovery-password/{recoveryId}")]
        public async Task<IActionResult> ChangePasswordAtRecoveryAsync
            ([FromRoute] Guid recoveryId, [FromBody]ChangePasswordAtRecoveryDto model)
        {
            model.RecoveryId = recoveryId;
            await _service.ChangePasswordAtRecoveryAsync(model);

            return Ok();
        }

        /// <summary>
        /// Endpoint handling process of expiration refresh tokens, 
        /// after invoke this operation if user will try to generate 
        /// new token from expired refresh in session he will recive exception 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("revoke-token")]
        public async Task<IActionResult> RevokeTokenAsync([FromBody] RevokeTokenDto model)
        {
            await _service.RevokeTokenAsync(model);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("change-creedentials")]
        public async Task<IActionResult> ChangeCreedentialsAsync([FromBody] ChangeCreedentialsDto model)
        {
            await _service.ChangeCreedentials(model);

            return Ok();
        }
    }
}
