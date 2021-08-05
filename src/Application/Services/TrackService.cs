using Application.Commons.Mappers;
using Application.Commons.Services;
using Application.Dto.Track;
using Core.Commons.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TrackService : ITrackService
    {
        private readonly ILogger<TrackService> _logger;
        private readonly ITrackRepository _trackRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITrackMapper _mapper;
        private readonly Guid userId;

        public TrackService(ILogger<TrackService> logger, ITrackRepository trackRepository,
            IHttpContextAccessor httpContextAccessor, ITrackMapper mapper)
        {
            _logger = logger;
            _trackRepository = trackRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            userId = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated ?
                Guid.Parse(_httpContextAccessor.HttpContext.User.Identity.Name) : Guid.Empty;
        }

        public async Task<IEnumerable<GetTracksDto>> BrowseAsync()
        {
            var tracks = await _trackRepository.GetAllAsync();

            return _mapper.MapTo(tracks);
        }

        public async Task<GetTrackDto> GetAsync(string title)
        {
            var track = await _trackRepository.GetAsync(title);

            return _mapper.MapTo(track);
        }

        public async Task UploadAsync(UploadTrackDto model)
        {
            //Need to add logic to send and store file
            await _trackRepository.AddAsync(new());
        }
    }
}
