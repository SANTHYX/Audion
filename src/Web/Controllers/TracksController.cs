using Application.Commons.Services.Business;
using Application.Dto.Track;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly ITrackService _service;

        public TracksController(ITrackService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet("{title}")]
        public async Task<IActionResult> GetAsync(string title)
            => Ok(await _service.GetAsync(title));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> BrowseAsync([FromQuery] BrowseTracksQueryDto query)
            => Ok(await _service.BrowseAsync(query));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UploadAsync([FromForm] UploadTrackDto model)
        {
            await _service.UploadAsync(model);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] Guid id)
        {
            RemoveTrackDto model = new() { Id = id };
            await _service.RemoveAsync(model);

            return Ok();
        }
    }
}
