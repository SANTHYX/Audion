using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Application.Commons.Services.Business;
using Application.Dto.Identity.Requests;

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
        /// <param name="model">Object with refresh token</param>
        /// <returns>Object wit access token and metadata</returns>
        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenDto model)
        {
            var refreshToken = await _service.RefreshToken(model);

            return Ok(refreshToken);
        }

        /// <summary>
        /// Endpoint handle making recovery thread, after that service will send email message
        /// to user with link to route handling change password operation
        /// </summary>
        /// <param name="model">Object including mail</param>
        /// <returns></returns>
        [HttpPost("recovery-password")]
        public async Task<IActionResult> RecoveryPasswordAsync([FromBody] RecoveryPasswordDto model)
        {
            await _service.CreateRecoveryPasswordThreadAsync(model);

            return Ok();
        }

        /// <summary>
        /// Endpoint handle operation to set new user password at recovery
        /// </summary>
        /// <param name="recoveryId">Id of created thread</param>
        /// <param name="model">New user password</param>
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
        /// <param name="model">Object containing refresh token</param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("revoke-token")]
        public async Task<IActionResult> RevokeTokenAsync([FromBody] RevokeTokenDto model)
        {
            await _service.RevokeTokenAsync(model);

            return Ok();
        }

        /// <summary>
        /// Endpoint handle setting new password for authenticated user
        /// </summary>
        /// <param name="model">Object with old and new password</param>
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
