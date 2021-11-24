using Application.Commons.Services;
using Application.Dto.Profile;
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

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProfileDto model)
        {
            await _service.CreateAsync(model);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProfileDto model)
        {
            await _service.UpdateAsync(model);

            return Ok();
        } 

        [HttpPut("upload-avatar")]
        public async Task<IActionResult> UploadAvatarAsync([FromForm] UploadAvatarDto model)
        {
            await _service.UploadAvatarAsync(model);

            return Ok();
        }
    }
}
