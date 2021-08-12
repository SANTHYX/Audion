using Application.Commons.Mappers;
using Application.Commons.Services;
using Application.Dto;
using Application.Dto.Track;
using Core.Commons.Pagination;
using Core.Commons.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TrackService : ITrackService
    {
        private readonly ILogger<TrackService> _logger;
        private readonly ITrackRepository _trackRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITrackMapper _mapper;
        private readonly Guid userId;

        public TrackService(ILogger<TrackService> logger, ITrackRepository trackRepository, 
            IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, ITrackMapper mapper)
        {
            _logger = logger;
            _trackRepository = trackRepository;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            userId = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated ?
                Guid.Parse(_httpContextAccessor.HttpContext.User.Identity.Name) : Guid.Empty;
        }

        public async Task<PagedResponseDto<GetTracksDto>> BrowseAsync(PagedQuery query)
        {
            _logger.LogInformation("Fetching filtred data...");
            var tracks = await _trackRepository.GetAllAsync(x => x.Title == "", query);

            return _mapper.MapTo(tracks);
        }

        public async Task<GetTrackDto> GetAsync(string title)
        {
            _logger.LogInformation("Fetching track...");
            var track = await _trackRepository.GetAsync(title);

            return _mapper.MapTo(track);
        }

        public async Task UploadAsync(UploadTrackDto model)
        {
            var user = await _userRepository.GetAsync(userId);
            //Need to add logic to send and store file
            await _trackRepository.AddAsync(new(model.Title, user));
        }
    }
}
