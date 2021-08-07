using Application.Commons.Services;
using Application.Dto.Track;
using Core.Commons.Pagination;
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

        [HttpGet("{title}")]
        public async Task<IActionResult> Get(string title)
            => Ok(await _service.GetAsync(title));

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PagedQuery query)
            => Ok(await _service.BrowseAsync(query));

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] UploadTrackDto model)
        {
            await _service.UploadAsync(model);

            return Ok();
        }
    }
}
