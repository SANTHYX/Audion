using Application.Services;
using Core.Commons.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;

namespace Application.UnitTests
{
    public class ProfileServiceTests
    {
        private readonly Mock<ILogger<ProfileService>> _loggerMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IProfileRepository> _profileRepositoryMock;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
        private readonly ProfileService _service;

        public ProfileServiceTests()
        {

        }
    }
}
