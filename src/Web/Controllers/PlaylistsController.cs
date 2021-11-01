using Application.Commons.Services;
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

        [HttpGet("id")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await _service.GetAsync(id));

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PagedQuery query)
            => Ok(await _service.BrowseAsync(query));

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePlaylistDto model)
        {
            await _service.CreateAsync(model);

            return Ok();
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePlaylistDto model)
        {
            await _service.UpdateAsync(model);

            return Ok();
        }

        [Authorize]
        [HttpDelete("id")]
        public async Task<IActionResult> Delete([FromBody] DeletePlaylistDto model)
        {
            return Ok();
        }
    }
}
