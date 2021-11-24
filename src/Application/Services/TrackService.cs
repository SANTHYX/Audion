using Application.Commons.Identity;
using Application.Commons.Mappers;
using Application.Commons.Services;
using Application.Commons.Toolkits.Files;
using Application.Commons.Types;
using Application.Dto;
using Application.Dto.Track;
using Application.Extensions.Validations;
using Application.Extensions.Validations.Track;
using Core.Commons.Pagination;
using Core.Commons.Persistance;
using Core.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TrackService : ITrackService
    {
        private readonly ILogger<TrackService> _logger;
        private readonly IUserProvider _provider;
        private readonly IUnitOfWork _unit;
        private readonly ITrackMapper _mapper;
        private readonly IStaticFileManager<IAudioFile> _fileManager;
        private readonly Guid _userId;

        public TrackService(
            ILogger<TrackService> logger,
            IUserProvider provider,
            IUnitOfWork unit,
            ITrackMapper mapper,
            IStaticFileManager<IAudioFile> fileManager)
        {
            _logger = logger;
            _unit = unit;
            _mapper = mapper;
            _provider = provider;
            _fileManager = fileManager;
            _userId = _provider.CurrentUserId;
        }

        public async Task<GetTrackDto> GetAsync(string title)
        {
            _logger.LogInformation($"Fetching object with Title '{ title }'...");

            var track = await _unit.Track.GetAsync(title);

            track.NotNull();

            return _mapper.MapTo<GetTrackDto>(track);
        }

        public async Task<PagedResponseDto<GetTracksDto>> BrowseAsync(PagedQuery query)
        {
            _logger.LogInformation("Fetching collection...");

            var tracks = await _unit.Track.GetAllAsync(x => x.Title == "", query);

            return _mapper.MapTo<PagedResponseDto<GetTracksDto>>(tracks);
        }

        public async Task UploadAsync(UploadTrackDto model)
        {
            var user = await _unit.User.GetRelationalAsync(_userId);

            user.NotNull();

            var trackId = Guid.NewGuid().ToString();
            await _fileManager.SaveAsync(model.Track, trackId);
   
            Track track = new(model.Title, trackId, user);
            await _unit.Track.AddAsync(track);
            await _unit.CommitAsync();
        }

        public async Task RemoveAsync(RemoveTrackDto model)
        {
            var track = await _unit.Track.GetAsync(model.Id);

            track.NotNull().OwnedByCurrentUser(_userId);

            _fileManager.Remove(track.TrackId);

            _unit.Track.Remove(track);
            await _unit.CommitAsync();
        }
    }
}
