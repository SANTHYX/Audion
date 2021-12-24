using Application.Commons.Services.Business;
using Application.Dto.User;
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

        /// <summary>
        /// Endpoint returns informations about user instance.
        /// Endpoint doesn't require authentication
        /// </summary>
        /// <param name="userName">Current userName</param>
        /// <returns>Object representing user instance</returns>
        [HttpGet("{userName}")]
        public async Task<IActionResult> GetAsync(string userName)
            => Ok(await _service.GetAsync(userName));

        /// <summary>
        /// Endpoint returns collection of users fullyfing details included in query parameters.
        /// Endpoint doesn't require authentication
        /// </summary>
        /// <param name="query">Query object including query parameters</param>
        /// <returns>Object including collection of users with page details</returns>
        [HttpGet]
        public async Task<IActionResult> BrowseAsync([FromQuery] BrowseUsersQueryDto query)
            => Ok(await _service.BrowseAsync(query));
    }
}
