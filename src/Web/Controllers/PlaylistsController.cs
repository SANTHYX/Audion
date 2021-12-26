using Application.Commons.Services.Business;
using Application.Dto.Playlist.Requests;
using Core.Commons.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylistService _service;

        public PlaylistsController(IPlaylistService service)
        {
            _service = service;
        }

        /// <summary>
        /// Endpoint perform returning single playlist instance by Id.
        /// Endpoint doesn't require authentication
        /// </summary>
        /// <param name="id">Id of object</param>
        /// <returns>Object if will be found, otherwise null value</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
            => Ok(await _service.GetAsync(id));

        /// <summary>
        /// Endpoint perform returning collection of playlists fullyfing details included in query parameters.
        /// Endpoint doesn't require authentication
        /// </summary>
        /// <param name="query">Object including query parameters</param>
        /// <returns>Object with collection of playlists and metadata about page</returns>
        [HttpGet]
        public async Task<IActionResult> BrowseAsync([FromQuery] BrowsePlaylistQueryDto query)
            => Ok(await _service.BrowseAsync(query));

        /// <summary>
        /// Endpoint perform returning collection of playlists belongs to authenticated user.
        /// Endpoint require authentication
        /// </summary>
        /// <param name="query">Object including query parameters</param>
        /// <returns>Object with collection of playlists and metadata about page</returns>
        [Authorize]
        [HttpGet("user")]
        public async Task<IActionResult> BrowseForCurrentAsync([FromQuery] BrowseUserPlaylistsQueryDto query)
            => Ok(await _service.BrowseForCurrentUserAsync(query));

        /// <summary>
        /// Endpoint perform creating a instance of playlist. Endpoint require authentication
        /// </summary>
        /// <param name="model">Object including data for new playlist</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePlaylistDto model)
        {
            await _service.CreateAsync(model);

            return Ok();
        }

        /// <summary>
        /// Endpoint perform changing a instance of playlist. Endpoint require authentication
        /// </summary>
        /// <param name="model">Object including new values for playlist</param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdatePlaylistDto model)
        {
            await _service.UpdateAsync(model);

            return Ok();
        }

        /// <summary>
        /// Endpoint perform removing playlist object by Id. Endpoint require authentication
        /// </summary>
        /// <param name="id">Id of object</param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] Guid id)
        {
            RemovePlaylistDto model = new() { Id = id };
            await _service.RemoveAsync(model);

            return Ok();
        }
    }
}
