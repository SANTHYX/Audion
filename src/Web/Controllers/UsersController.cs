using Application.Commons.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("{ userName }")]
        public async Task<IActionResult> GetAsync(string userName)
            => Ok(await _service.GetAsync(userName));
    }
}
