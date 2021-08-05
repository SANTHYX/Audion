using Application.Commons.Services;
using Application.Dto.Playlist;
using Core.Commons.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public Task<IEnumerable<GetPlaylistsDto>> BrowseAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetPlaylistDto> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
