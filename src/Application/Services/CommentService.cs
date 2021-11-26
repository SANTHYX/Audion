using Application.Commons.Identity;
using Application.Commons.Services;
using Application.Dto.Comment;
using Core.Commons.Persistance;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Application.Services
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

        public async Task AddCommentAsync(AddCommentDto model)
        {
            var user = _unit.User.GetRelationalAsync(_userId);
        }
        
        public async Task EditCommentAsync(EditCommentDto model)
        {
            var user = _unit.User.GetRelationalAsync(_userId);
        }
    }
}
