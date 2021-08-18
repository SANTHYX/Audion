using Application.Commons.Identity;
using Application.Dto.Identity;
using Application.Dto.User;
using Application.Services;
using Core.Commons.Repositories;
using Core.Domain;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

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

        [Fact]
        public async Task Is_LoginAsync_throws_exception_when_credeentials_are_wrong()
        {
            string testLogin = "testLogin";
            string testPassword = "testPassword";
            LoginUserDto testModel = new()
            {
                UserName = testLogin,
                Password = testPassword
            };

            _userRepositoryMock.Setup(x => x.GetAsync(testLogin))
                .ReturnsAsync(()=> null);
            _encryptorMock.Setup(x => x.IsValidPassword(null,testPassword))
                .Returns(()=> false); 
            
            Func<Task<GetJwtTokenDto>> loginAsyncTask = () => _service.LoginAsync(testModel);
            await loginAsyncTask.Should().ThrowAsync<UnauthorizedAccessException>();
        }

        [Fact]
        public async Task Is_LoginAsync_throws_exception_when_only_password_is_wrong()
        {
            string testLogin = "testLogin";
            string testPassword = "testPassword";
            User testUser = new(testLogin, "diffPassowrd", "testSalt", "testmail@gmail.com");
            LoginUserDto testModel = new()
            {
                UserName = testLogin,
                Password = testPassword
            };

            _userRepositoryMock.Setup(x => x.GetAsync(testLogin))
                .ReturnsAsync(() => testUser);
            _encryptorMock.Setup(x => x.IsValidPassword(testUser, testPassword))
                .Returns(() => false);

            Func<Task<GetJwtTokenDto>> loginAsyncTask = () => _service.LoginAsync(testModel);
            await loginAsyncTask.Should().ThrowAsync<UnauthorizedAccessException>();
        }

        //Need to end...
        [Fact]
        public async Task Is_LoginAsync_returns_access_data_when_creedentials_will_be_valid()
        {
            string testLogin = "testLogin";
            string testPassword = "testPassword";
            User testUser = new(testLogin, testPassword, "testSalt", "testmail@gmail.com");
            LoginUserDto testModel = new()
            {
                UserName = testLogin,
                Password = testPassword
            };

            _userRepositoryMock.Setup(x => x.GetAsync(testLogin))
                .ReturnsAsync(() => testUser);
            _encryptorMock.Setup(x => x.IsValidPassword(testUser, testPassword))
                .Returns(() => true);
        }

        [Fact]
        public async Task Is_RegisterAsync_throws_exception_when_userName_with_passed_userName_exists()
        {
            string testUserName = "TestUserName";
            string testPassword = "testPassword";
            string testMail = "testmail@gmail.com";
            RegisterUserDto testModel = new()
            {
                UserName = testUserName,
                Password = testPassword,
                Email = testMail
            };

            _userRepositoryMock.Setup(x => x.IsExist(testUserName))
                .ReturnsAsync(() => true);

            Func<Task> registerAsyncTask = () => _service.RegisterAsync(testModel);
            await registerAsyncTask.Should().ThrowAsync<Exception>();
        }
    }
}
