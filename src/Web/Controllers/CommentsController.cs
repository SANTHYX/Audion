using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Commons.Services.Business;
using Application.Dto.Comment.Requests;
using Microsoft.AspNetCore.Authorization;

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
        /// Endpoint perform posting comment in track comment section. Endpoint require authentication
        /// </summary>
        /// <param name="model">Object including message and Id of track</param>
        /// <returns></returns>
        [HttpPost("track")]
        public async Task<IActionResult> CommentTrackAsync([FromBody] AddCommentDto model)
        {
            await _service.CommentTrackAsync(model);

            return Ok();
        }

        /// <summary>
        /// Endpoint perform posting comment in track comment section. Endpoint require authentication
        /// </summary>
        /// <param name="model">Object including message and Id of playlist</param>
        /// <returns></returns>
        [HttpPost("playlist")]
        public async Task<IActionResult> CommentPlaylistAsync([FromBody] AddCommentDto model)
        {
            await _service.CommentPlaylistAsync(model);

            return Ok();
        }

        /// <summary>
        /// Endpoint perform changing posted comment in track comment section. Endpoint require authentication
        /// </summary>
        /// <param name="model">Object including Id of message and new message</param>
        /// <returns></returns>
        [HttpPut("track")]
        public async Task<IActionResult> EditTrackCommentAsync([FromBody] EditCommentDto model)
        {
            await _service.EditTrackCommentAsync(model);

            return Ok();
        }

        /// <summary>
        /// Endpoint perform changing posted comment in playlist comment section. Endpoint require authentication
        /// </summary>
        /// <param name="model">Object including Id of message and new message</param>
        /// <returns></returns>
        [HttpPut("playlist")]
        public async Task<IActionResult> EditPlaylistCommentAsync([FromBody] EditCommentDto model)
        {
            await _service.EditPlaylistCommentAsync(model);

            return Ok();
        }

        /// <summary>
        /// Endpoint perform replaying on other users comments. Endpoint require authentication
        /// </summary>
        /// <param name="model">Object including Id of comment that we will reply and message</param>
        /// <returns></returns>
        [HttpPost("{id}/reply")]
        public async Task<IActionResult> ReplyToCommentAsync([FromRoute] Guid id, [FromBody] ReplyCommentDto model)
        {
            await _service.ReplyToCommentAsync(model);

            return Ok();
        }
    }
}
