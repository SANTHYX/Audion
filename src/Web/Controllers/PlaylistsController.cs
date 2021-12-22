using Application.Commons.Services.Business;
using Application.Dto.Playlist;
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
            => Ok(await _service.GetAsync(id));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> BrowseAsync([FromQuery] BrowsePlaylistQueryDto query)
            => Ok(await _service.BrowseAsync(query));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("user")]
        public async Task<IActionResult> BrowseForCurrentAsync([FromQuery] PagedQuery query)
            => Ok(await _service.BrowseForCurrentUserAsync(query));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePlaylistDto model)
        {
            await _service.CreateAsync(model);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdatePlaylistDto model)
        {
            await _service.UpdateAsync(model);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            RemovePlaylistDto model = new() { Id = id };
            await _service.RemoveAsync(model);

            return Ok();
        }
    }
}
