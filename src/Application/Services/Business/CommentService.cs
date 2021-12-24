using Application.Commons.Identity;
using Application.Commons.Services.Business;
using Application.Dto.Comment.Requests;
using Core.Commons.Persistance;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Application.Services.Business
{
    public class CommentService : ICommentService
    {
        private readonly ILogger<CommentService> _logger;
        private readonly IUnitOfWork _unit;
        private readonly IUserProvider _provider;
        private readonly Guid _userId;

        public CommentService(ILogger<CommentService> logger, IUnitOfWork unit, IUserProvider provider)
        {
            _logger = logger;
            _unit = unit;
            _provider = provider;
            _userId = _provider.CurrentUserId;
        }

        public async Task CommentTrackAsync(AddCommentDto model)
        {
            var user = _unit.User.GetByIdAsync(_userId);
        }

        public async Task CommentPlaylistAsync(AddCommentDto model)
        {
            throw new NotImplementedException();
        }

        public async Task EditTrackCommentAsync(EditCommentDto model)
        {
            var user = _unit.User.GetByIdAsync(_userId);
        }

        public async Task EditPlaylistCommentAsync(EditCommentDto model)
        {
            throw new NotImplementedException();
        }

        public async Task ReplyToCommentAsync(ReplyCommentDto model)
        {
            throw new NotImplementedException();
        }
    }
}
