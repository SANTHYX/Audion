using Application.Commons.Mappers;
using Application.Commons.Services;
using Application.Dto;
using Application.Dto.Playlist;
using Core.Commons.Pagination;
using Core.Commons.Persistance;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IUnitOfWork _unit;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPlaylistMapper _mapper;
        private readonly Guid userId;

        public PlaylistService(IUnitOfWork unit, IHttpContextAccessor httpContextAccessor, IPlaylistMapper mapper)
        {
            _unit = unit;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            userId = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated 
                ? Guid.Parse(_httpContextAccessor.HttpContext.User.Identity.Name) : Guid.Empty;
        }

        public async Task<PagedResponseDto<GetPlaylistsDto>> BrowseAsync(PagedQuery query)
        {
            var playlists = await _unit.Playlist
                .GetAllAsync(x => x.Name == "x",query);

            return _mapper.MapTo(playlists);
        }

        public async Task CreateAsync(CreatePlaylistDto model)
        {
            var user = await _unit.User.GetAsync(userId);
            await _unit.Playlist.AddAsync(new(model.Name, user));
            await _unit.CommitAsync();
        }

        public async Task<GetPlaylistDto> GetAsync(Guid id)
        {
            var playlist = await _unit.Playlist.GetAsync(id);

            return _mapper.MapTo(playlist);
        }

        public async Task RemoveAsync(Guid id)
        {
            var playlist = await _unit.Playlist.GetAsync(id);
            _unit.Playlist.Remove(playlist);
            await _unit.CommitAsync();
        }

        public async Task UpdateAsync(UpdatePlaylistDto model)
        {
            var playlist = await _unit.Playlist.GetAsync(model.Id);
            //Edit Logic and validation
            _unit.Playlist.Update(playlist);
            await _unit.CommitAsync();
        }
    }
}
