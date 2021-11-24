using Application.Commons.Identity;
using Application.Commons.Mappers;
using Application.Commons.Services;
using Application.Dto;
using Application.Dto.Playlist;
using Application.Extensions.Validations;
using Application.Extensions.Validations.Playlist;
using Core.Commons.Pagination;
using Core.Commons.Persistance;
using Core.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly ILogger<PlaylistService> _logger;
        private readonly IUnitOfWork _unit;
        private readonly IUserProvider _provider;
        private readonly IPlaylistMapper _mapper;
        private readonly Guid _userId;

        public PlaylistService(
            ILogger<PlaylistService> logger,
            IUnitOfWork unit,
            IUserProvider provider,
            IPlaylistMapper mapper)
        {
            _logger = logger;
            _unit = unit;
            _provider = provider;
            _mapper = mapper;
            _userId = _provider.CurrentUserId;
        }

        public async Task<GetPlaylistDto> GetAsync(Guid id)
        {
            _logger.LogInformation($"Fetching object with Id '{ id }'...");

            var playlist = await _unit.Playlist.GetAsync(id);

            return _mapper.MapTo<GetPlaylistDto>(playlist);
        }

        public async Task<PagedResponseDto<GetPlaylistsDto>> BrowseAsync(PagedQuery query)
        {
            _logger.LogInformation($"Fetching playlists collection...");

            var playlists = await _unit.Playlist
                .GetAllAsync(x => 
                    x.Name.Contains(query.Name),
                query);

            return _mapper.MapTo<PagedResponseDto<GetPlaylistsDto>>(playlists);
        }

        public async Task CreateAsync(CreatePlaylistDto model)
        {
            var user = await _unit.User.GetRelationalAsync(_userId);

            Playlist playlist = new(model.Name, user);
            await _unit.Playlist.AddAsync(playlist);
            await _unit.CommitAsync();
        }

        public async Task UpdateAsync(UpdatePlaylistDto model)
        {
            var playlist = await _unit.Playlist.GetAsync(model.Id);

            playlist.NotNull().OwnedByUser(_userId);

            _unit.Playlist.Update(playlist);
            await _unit.CommitAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var playlist = await _unit.Playlist.GetAsync(id);

            playlist.NotNull().OwnedByUser(_userId);

            _unit.Playlist.Remove(playlist);
            await _unit.CommitAsync();
        }
    }
}
