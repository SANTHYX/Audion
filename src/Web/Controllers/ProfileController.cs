using Application.Commons.Services.Business;
using Application.Dto.Profile.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _service;

        public ProfileController(IProfileService service)
        {
            _service = service;
        }

        /// <summary>
        /// Endpoint perform creating instance of profile. Endpoint require authentication
        /// </summary>
        /// <param name="model">Object including data for new profile</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProfileDto model)
        {
            await _service.CreateAsync(model);

            return Ok();
        }

        /// <summary>
        /// Endpoint perform changes of profile instance. Endpoint require authentication 
        /// </summary>
        /// <param name="model">Object including properties keeping new values for profile instance</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProfileDto model)
        {
            await _service.UpdateAsync(model);

            return Ok();
        }

        /// <summary>
        /// Endpoint perform serialization of avatar for profile on server. Endpoint require authentication
        /// </summary>
        /// <param name="model">Object include image file</param>
        /// <returns></returns>
        [HttpPut("upload-avatar")]
        public async Task<IActionResult> UploadAvatarAsync([FromForm] UploadAvatarDto model)
        {
            await _service.UploadAvatarAsync(model);

            return Ok();
        }
    }
}
