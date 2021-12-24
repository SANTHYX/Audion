using Application.Commons.Services.Business;
using Application.Dto.Identity.Requests;
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
        /// Endpoint perform user authentication and return object with creedentials.
        /// If he pass proccess sucesfully, controller will return access token.
        /// Endpoint doesn't require authentication
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
        /// Endpoint perform registration user instance to system.
        /// Endpoint doesn't require authentication
        /// </summary>
        /// <param name="model">Informations required to create user instance</param>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserDto model)
        {
            await _service.RegisterAsync(model);

            return Ok();
        }

        /// <summary>
        /// Endpoint perform generation of new access tokens for sign-in users after expire.
        /// Endpoint doesn't require authentication
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
        /// Endpoint perform making recovery thread, after that service will send email message
        /// to user with link to route handling change password operation
        /// Endpoint doesn't require authentication
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
        /// Endpoint perform operation to set new user password at recovery
        /// Endpoint doesn't require authentication
        /// </summary>
        /// <param name="recoveryId">Id of created thread</param>
        /// <param name="model">New user password</param>
        /// <returns></returns>
        [HttpPut("recovery-password/{recoveryId}")]
        public async Task<IActionResult> ChangePasswordAtRecoveryAsync
            ([FromRoute] Guid recoveryId, [FromBody] ChangePasswordAtRecoveryDto model)
        {
            model.RecoveryId = recoveryId;
            await _service.ChangePasswordAtRecoveryAsync(model);

            return Ok();
        }

        /// <summary>
        /// Endpoint perform expiring of refresh tokens, 
        /// after invoke this operation if user will try to generate 
        /// new token from expired refresh in session he will recive exception.
        /// Endpoint doesn't require authentication
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
        /// Endpoint perform setting new password for authenticated user
        /// Endpoint doesn't require authentication
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
