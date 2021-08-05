using Application.Commons.Mappers;
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
        private readonly IPlaylistMapper _mapper;
        private readonly Guid userId;

        public PlaylistService(IPlaylistRepository playlistRepository, IHttpContextAccessor httpContextAccessor,
            IPlaylistMapper mapper)
        {
            _playlistRepository = playlistRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            userId = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated 
                ? Guid.Parse(_httpContextAccessor.HttpContext.User.Identity.Name) : Guid.Empty;
        }

        public async Task<IEnumerable<GetPlaylistsDto>> BrowseAsync()
        {
            var playlists = await _playlistRepository.GetAllAsync();

            return _mapper.MapTo(playlists);
        }

        public async Task CreateAsync(CreatePlaylistDto model)
        {
            await _playlistRepository.AddAsync(new());
        }

        public async Task<GetPlaylistDto> GetAsync(Guid id)
        {
            var playlist = await _playlistRepository.GetAsync(id);

            return _mapper.MapTo(playlist);
        }

        public async Task RemoveAsync(Guid id)
        {
            var playlist = await _playlistRepository.GetAsync(id);
            await _playlistRepository.RemoveAsync(playlist);
        }

        public async Task UpdateAsync(UpdatePlaylistDto model)
        {
            var playlist = await _playlistRepository.GetAsync(model.Id);
            //Edit Logic and validation
            await _playlistRepository.UpdateAsync(playlist);
        }
    }
}
