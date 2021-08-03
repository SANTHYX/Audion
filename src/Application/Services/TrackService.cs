using Application.Commons.Mappers;
using Application.Commons.Services;
using Core.Commons.Repositories;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITrackMapper _mapper;

        public TrackService(ITrackRepository trackRepository, IHttpContextAccessor httpContextAccessor, ITrackMapper mapper)
        {
            _trackRepository = trackRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
    }
}
