using Application.Commons.Services;
using Application.Dto.Playlist;
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
            => Ok(await _service.GetAsync());

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.BrowseAsync());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePlaylistDto model)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePlaylistDto model)
        {
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete([FromBody] DeletePlaylistDto model)
        {
            return Ok();
        }
    }
}
