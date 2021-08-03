using Application.Commons.Services;
using Core.Commons.Repositories;
using Microsoft.AspNetCore.Http;
using System;

namespace Application.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Guid userId;

        public PlaylistService(IPlaylistRepository playlistRepository, IHttpContextAccessor httpContextAccessor)
        {
            _playlistRepository = playlistRepository;
            _httpContextAccessor = httpContextAccessor;
            userId = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated 
                ? Guid.Parse(_httpContextAccessor.HttpContext.User.Identity.Name) : Guid.Empty;
        }
    }
}
