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
        /// Endpoint returns informations about user instance
        /// </summary>
        /// <param name="userName">Current userName</param>
        /// <returns>Object representing user instance</returns>
        [HttpGet("{userName}")]
        public async Task<IActionResult> GetAsync(string userName)
            => Ok(await _service.GetAsync(userName));

        /// <summary>
        /// Endpoint returns collection of users containing details given from query
        /// </summary>
        /// <param name="query">Query object including querying parameters</param>
        /// <returns>Object including collection of users with page details</returns>
        [HttpGet]
        public async Task<IActionResult> BrowseAsync([FromQuery] BrowseUsersQueryDto query)
            => Ok(await _service.BrowseAsync(query));
    }
}
