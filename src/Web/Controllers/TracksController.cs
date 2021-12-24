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
        /// Endpoint returning track instance by Id. Endpoint doesn't require authentication
        /// </summary>
        /// <param name="id">Id of track</param>
        /// <returns>Object including track metadata with URL to static file</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
            => Ok(await _service.GetAsync(id));

        /// <summary>
        /// Endpoint return collection of tracks fullyfing details included in query parameters.
        /// Endpoint doesnt require authentication
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Object including collection of playlists with metadata about page</returns>
        [HttpGet]
        public async Task<IActionResult> BrowseAsync([FromQuery] BrowseTracksQueryDto query)
            => Ok(await _service.BrowseAsync(query));

        /// <summary>
        /// Endpoint perform serialization of send music file on server. Acceptable file formats are *.wav and *.mp3.
        /// Endpoint require authentication
        /// </summary>
        /// <param name="model">Object with file and file name</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UploadAsync([FromForm] UploadTrackDto model)
        {
            await _service.UploadAsync(model);

            return Ok();
        }

        /// <summary>
        /// Endpoint perform removing track by Id. Endpoint require user authentication
        /// </summary>
        /// <param name="id">Id of object</param>
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
