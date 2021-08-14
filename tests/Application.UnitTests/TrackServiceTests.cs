using Application.Commons.Mappers;
using Application.Services;
using Core.Commons.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;

namespace Application.UnitTests
{
    public class TrackServiceTests
    {
        private readonly Mock<ILogger<TrackService>> _loggerMock;
        private readonly Mock<ITrackRepository> _trackRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
        private readonly Mock<ITrackMapper> _mapperMock;
        private readonly TrackService _service;

        public TrackServiceTests()
        {
            _loggerMock = new();
            _trackRepositoryMock = new();
            _userRepositoryMock = new();
            _httpContextAccessorMock = new();
            _mapperMock = new();
            _service = new(_loggerMock.Object, _trackRepositoryMock.Object,
                _userRepositoryMock.Object, _httpContextAccessorMock.Object, 
                _mapperMock.Object);
        }
    }
}
