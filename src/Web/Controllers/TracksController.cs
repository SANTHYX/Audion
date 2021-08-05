using Application.Commons.Services;
using Application.Dto.Track;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await _service.GetAsync());

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.BrowseAsync());

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] UploadTrackDto model)
        {
            await _service.UploadAsync();

            return Ok();
        }
    }
}
