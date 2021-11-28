using Application.Commons.Services.Business;
using Application.Dto.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _service;

        public CommentsController(ICommentService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("track")]
        public async Task<IActionResult> CommentTrackAsync([FromBody] AddCommentDto model)
        {
            await _service.CommentTrackAsync(model);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("playlist")]
        public async Task<IActionResult> CommentPlaylistAsync([FromBody] AddCommentDto model)
        {
            await _service.CommentPlaylistAsync(model);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("track")]
        public async Task<IActionResult> EditTrackCommentAsync([FromBody] EditCommentDto model)
        {
            await _service.EditTrackCommentAsync(model);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("playlist")]
        public async Task<IActionResult> EditPlaylistCommentAsync([FromBody] EditCommentDto model)
        {
            await _service.EditPlaylistCommentAsync(model);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("{id}/reply")]
        public async Task<IActionResult> ReplyToCommentAsync([FromRoute] Guid id, [FromBody] ReplyCommentDto model)
        {
            await _service.ReplyToCommentAsync(model);

            return Ok();
        }
    }
}
