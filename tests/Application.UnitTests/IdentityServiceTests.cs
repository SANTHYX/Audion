using Application.Commons.Identity;
using Application.Services;
using Core.Commons.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Application.UnitTests
{
    public class  IdentityServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<ITokenRepository> _tokenRepositoryMock;
        private readonly Mock<IEncryptor> _encryptorMock;
        private readonly Mock<IJwtHandler> _jwtHandlerMock;
        private readonly Mock<ILogger<IdentityService>> _loggerMock;
        private readonly IdentityService _service;

        public IdentityServiceTests()
        {
            _userRepositoryMock = new();
            _tokenRepositoryMock = new();
            _encryptorMock = new();
            _jwtHandlerMock = new();
            _loggerMock = new();
            _service = new(_userRepositoryMock.Object, _tokenRepositoryMock.Object,
                _encryptorMock.Object, _jwtHandlerMock.Object, 
                _loggerMock.Object);
        }


    }
}
