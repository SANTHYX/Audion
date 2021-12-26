using Application.Commons.Identity;
using Application.Commons.Mappers;
using Application.Commons.Services.Business;
using Application.Dto;
using Application.Dto.Playlist.Requests;
using Application.Dto.Playlist.Responses;
using Application.Extensions.Validations;
using Application.Extensions.Validations.Playlist;
using Core.Commons.Persistance;
using Core.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Application.Services.Business
{
    public class PlaylistService : IPlaylistService
    {
        private readonly ILogger<PlaylistService> _logger;
        private readonly IUnitOfWork _unit;
        private readonly IUserProvider _provider;
        private readonly IPlaylistMapper _mapper;
        private Guid _userId;

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

            var playlist = await _unit.Playlist.GetByIdAsync(id);

            return _mapper.MapTo<GetPlaylistDto>(playlist);
        }

        public async Task<PagedResponseDto<GetPlaylistCollectionDto>> BrowseAsync(BrowsePlaylistQueryDto query)
        {
            _logger.LogInformation($"Fetching playlists collection...");

            var playlists = await _unit.Playlist
                .GetAllAsync(x =>
                    (x.Name != null ? x.Name.ToLower().Contains(query.Name.ToLower()) : x.Name == null)
                , query);

            return _mapper.MapTo<PagedResponseDto<GetPlaylistCollectionDto>>(playlists);
        }

        public async Task<PagedResponseDto<GetPlaylistCollectionDto>> BrowseForCurrentUserAsync(BrowseUserPlaylistsQueryDto query)
        {
            _logger.LogInformation($"Fetching playlists collection...");

            var playlists = await _unit.Playlist
               .GetAllAsync(x => x.UserId == _userId, query);

            return _mapper.MapTo<PagedResponseDto<GetPlaylistCollectionDto>>(playlists);
        }

        public async Task CreateAsync(CreatePlaylistDto model)
        {
            await ValidateIsExistInUserCollection(_userId, model.Name);

            var user = await _unit.User.GetByIdAsync(_userId);

            Playlist playlist = new(model.Name, user);
            await _unit.Playlist.AddAsync(playlist);
            await _unit.CommitAsync();
        }

        public async Task UpdateAsync(UpdatePlaylistDto model)
        {
            var playlist = await _unit.Playlist.GetByIdAsync(model.Id);

            playlist.NotNull().OwnedByCurrentUser(_userId);

            _unit.Playlist.Update(playlist);
            await _unit.CommitAsync();
        }

        public async Task RemoveAsync(RemovePlaylistDto model)
        {
            var playlist = await _unit.Playlist.GetByIdAsync(model.Id);

            playlist.NotNull().OwnedByCurrentUser(_userId);

            _unit.Playlist.Remove(playlist);
            await _unit.CommitAsync();
        }

        private async Task ValidateIsExistInUserCollection(Guid userId, string playlistName)
        { 
            if (await _unit.Playlist.IsExistInUserCollection(userId, playlistName))
            {
                throw new Exception("Playlist with this name already exist in your collection");
            } 
        }
    }
}
