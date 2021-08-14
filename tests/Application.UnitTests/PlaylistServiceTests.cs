using Application.Commons.Mappers;
using Application.Services;
using Core.Commons.Repositories;
using Microsoft.AspNetCore.Http;
using Moq;

namespace Application.UnitTests
{
    public class PlaylistServiceTests
    {
        private readonly Mock<IPlaylistRepository> _playlistRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
        private readonly Mock<IPlaylistMapper> _mapperMock;
        private readonly PlaylistService _service;

        public PlaylistServiceTests()
        {
            _playlistRepositoryMock = new();
            _userRepositoryMock = new();
            _httpContextAccessorMock = new();
            _mapperMock = new();
            _service = new(_playlistRepositoryMock.Object, _userRepositoryMock.Object,
                _httpContextAccessorMock.Object, _mapperMock.Object);
        }
    }
}
