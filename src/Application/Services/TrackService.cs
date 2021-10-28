using Application.Commons.Mappers;
using Application.Commons.Services;
using Application.Commons.Toolkits.Files;
using Application.Commons.Types;
using Application.Dto;
using Application.Dto.Track;
using Application.Extensions.Validations;
using Core.Commons.Pagination;
using Core.Commons.Persistance;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TrackService : ITrackService
    {
        private readonly ILogger<TrackService> _logger;
        private readonly IUnitOfWork _unit;
        private readonly IHttpContextAccessor _accessor;
        private readonly ITrackMapper _mapper;
        private readonly IStaticFilesWriter<IAudioFile> _writer;
        private readonly Guid userId;

        public TrackService(
            ILogger<TrackService> logger,
            IUnitOfWork unit,
            IHttpContextAccessor accessor,
            ITrackMapper mapper, 
            IStaticFilesWriter<IAudioFile> writer)
        {
            _logger = logger;
            _unit = unit;
            _accessor = accessor;
            _mapper = mapper;
            _writer = writer;
            userId = _accessor.HttpContext.User.Identity.IsAuthenticated ?
                Guid.Parse(_accessor.HttpContext.User.Identity.Name) : Guid.Empty;
        }

        public async Task<PagedResponseDto<GetTracksDto>> BrowseAsync(PagedQuery query)
        {
            _logger.LogInformation("Fetching filtred data...");

            var tracks = await _unit.Track.GetAllAsync(x => x.Title == "", query);

            return _mapper.MapTo(tracks, _accessor.HttpContext);
        }

        public async Task<GetTrackDto> GetAsync(string title)
        {
            _logger.LogInformation("Fetching track...");

            var track = await _unit.Track.GetAsync(title);

            track.NotNull();

            return _mapper.MapTo(track);
        }

        public async Task UploadAsync(UploadTrackDto model)
        {
            var user = await _unit.User.GetAsync(userId);

            var trackId = Guid.NewGuid().ToString();
            await _writer.SaveAsync(model.Track, trackId);
            
            Track track = new(model.Title, trackId, user);

            await _unit.Track.AddAsync(track);
            await _unit.CommitAsync();
        }
    }
}
