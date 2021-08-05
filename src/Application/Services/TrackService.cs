using Application.Commons.Mappers;
using Application.Commons.Services;
using Application.Dto.Track;
using Core.Commons.Repositories;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public Task<IEnumerable<GetTracksDto>> BrowseAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<GetTrackDto> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task UploadAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
