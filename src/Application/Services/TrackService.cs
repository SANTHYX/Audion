using Application.Commons.Mappers;
using Application.Commons.Services;
using Application.Commons.Toolkits;
using Application.Dto;
using Application.Dto.Track;
using Core.Commons.Pagination;
using Core.Commons.Persistance;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITrackMapper _mapper;
        private readonly IFileManager _fileManager;
        private readonly Guid userId;

        public TrackService(ILogger<TrackService> logger, IUnitOfWork unit,
            IHttpContextAccessor httpContextAccessor,
            ITrackMapper mapper, IFileManager fileManager)
        {
            _logger = logger;
            _unit = unit;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _fileManager = fileManager;
            userId = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated ?
                Guid.Parse(_httpContextAccessor.HttpContext.User.Identity.Name) : Guid.Empty;
        }

        public async Task<PagedResponseDto<GetTracksDto>> BrowseAsync(PagedQuery query)
        {
            _logger.LogInformation("Fetching filtred data...");
            var tracks = await _unit.Track.GetAllAsync(x => x.Title == "", query);

            return _mapper.MapTo(tracks);
        }

        public async Task<GetTrackDto> GetAsync(string title)
        {
            _logger.LogInformation("Fetching track...");
            var track = await _unit.Track.GetAsync(title);

            return _mapper.MapTo(track);
        }

        //TODO: Edit to working usecase and decompose to SOLID like scenario
        public async Task UploadAsync(UploadTrackDto model)
        {
            var user = await _unit.User.GetAsync(userId);
            if (model.Track is null)
            {
                throw new ArgumentNullException(nameof(model.Track),"File is required");
            }
            await _fileManager.SaveAudioFileAsync(model.Track);
            await _unit.Track.AddAsync(new(model.Title, user));
            await _unit.CommitAsync();
        }
    }
}
