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

        [Fact]
        public async Task Is_LoginAsync_returns_access_data_when_creedentials_will_be_valid()
        {
            string testLogin = "testLogin";
            string testPassword = "testPassword";
            string testAccessToken = "eyji@#5dgx3!fRt3!5Yhffs&91Dt^&2r^36t";
            DateTime testExpiresAt = DateTime.Now.AddDays(5);
            User testUser = new(testLogin, testPassword, "testSalt", "testmail@gmail.com");
            Token testToken = new(testExpiresAt, testUser);
            LoginUserDto testModel = new()
            {
                UserName = testLogin,
                Password = testPassword
            };

            _userRepositoryMock.Setup(x => x.GetAsync(testLogin))
                .ReturnsAsync(() => testUser);
            _encryptorMock.Setup(x => x.IsValidPassword(testUser, testPassword))
                .Returns(() => true);
            _jwtHandlerMock.Setup(x => x.GenerateToken(testUser))
                .Returns(() => (testToken, testAccessToken));

            var token = await _service.LoginAsync(testModel);

            _tokenRepositoryMock.Verify(x => x.AddAsync(testToken), Times.Once);
            token.Should().NotBeNull();
            token.AccessToken.Should().Be(testAccessToken);
            token.Refresh.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Is_RefreshTokenAsync_throws_exception_when_refresh_dont_exist()
        {
            string testRefresh = Guid.NewGuid().ToString("N");
            RefreshTokenDto testModel = new()
            {
                RefreshToken = testRefresh
            };

            _tokenRepositoryMock.Setup(x => x.GetAsync(testRefresh))
                .ReturnsAsync(() => null);

            Func<Task> refreshTokenAsyncTask = () => _service.RefreshToken(testModel);
            await refreshTokenAsyncTask.Should().ThrowAsync<UnauthorizedAccessException>();
        }

        [Fact]
        public async Task Is_RefreshTokenAsync_throws_exception_when_passing_refresh_is_already_revoked()
        {
            string testRefresh = Guid.NewGuid().ToString("N");
            RefreshTokenDto testModel = new()
            {
                RefreshToken = testRefresh
            };

            _tokenRepositoryMock.Setup(x => x.GetAsync(testRefresh))
                .ReturnsAsync(() => Mock.Of<Token>(token => token.IsRevoked == true));

            Func<Task> refreshTokenAsyncTask = () => _service.RefreshToken(testModel);
            await refreshTokenAsyncTask.Should().ThrowAsync<Exception>();
        }

        /* To END!!!!!!
        [Fact]
        public async Task Is_RefreshTokenAsync_pass_when_refresh_is_active_()
        {
            string testRefresh = Guid.NewGuid().ToString("N");
            RefreshTokenDto testModel = new()
            {
                RefreshToken = testRefresh
            };

            _tokenRepositoryMock.Setup(x => x.GetAsync(testRefresh)) 
                .ReturnsAsync(() => Mock.Of<Token>(xd => xd.User == Mock.Of<User>()));
            _jwtHandlerMock.Setup(x => x.GenerateToken(Mock.Of<User>()))
                .Returns(() => (Mock.Of<Token>(), "accesToken"));
        }
        */

        [Fact]
        public async Task Is_RegisterAsync_throws_exception_when_user_with_passed_userName_exists()
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

        [Fact]
        public async Task Is_RegisterAsync_throws_exception_when_password_is_empty_and_task_try_to_hash_password()
        {
            string testUserName = "TestUserName";
            string testPassword = string.Empty;
            string testMail = "testmail@gmail.com";
            RegisterUserDto testModel = new()
            {
                UserName = testUserName,
                Password = testPassword,
                Email = testMail
            };

            _userRepositoryMock.Setup(x => x.IsExist(testUserName))
                .ReturnsAsync(() => false);
            _encryptorMock.Setup(x => x.HashPassword(testPassword))
                .Throws<ArgumentNullException>();

            Func<Task> registerAsyncTask = () => _service.RegisterAsync(testModel);
            await registerAsyncTask.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Is_RegisterAsync_pass_when_model_is_valid()
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
                .ReturnsAsync(() => false);
            _encryptorMock.Setup(x => x.HashPassword(testPassword))
                .Returns(()=> ("testHash", "testSalt"));

            Func<Task> registerAsyncTask = () => _service.RegisterAsync(testModel);
            await registerAsyncTask.Should().NotThrowAsync<Exception>();
        }

        [Fact]
        public async Task Is_RevokeTokenAsync_throws_exception_when_token_dont_exist()
        {
            string testRefreshToken = Guid.NewGuid().ToString("N");
            RevokeTokenDto testModel = new()
            {
                RefreshToken = testRefreshToken
            };

            _tokenRepositoryMock.Setup(x => x.GetAsync(testRefreshToken))
                .ReturnsAsync(() => null);

            Func<Task> revokeTokenTask = () => _service.RevokeTokenAsync(testModel);
            await revokeTokenTask.Should().ThrowAsync<UnauthorizedAccessException>();
        }

        [Fact]
        public async Task Is_RevokeTokenAsync_throws_exception_when_token_is_already_revoked()
        {
            string testRefreshToken = Guid.NewGuid().ToString("N");
            User testUser = new("testLogin", "testPassword", "testSalt", "testmail@gmail.com");
            Token testToken = new(DateTime.Now.AddDays(5), testUser);
            RevokeTokenDto testModel = new()
            {
                RefreshToken = testRefreshToken
            };

            _tokenRepositoryMock.Setup(x => x.GetAsync(testRefreshToken))
                .ReturnsAsync(() => testToken);
            testToken.RevokeToken();

            Func<Task> revokeTokenTask = () => _service.RevokeTokenAsync(testModel);
            await revokeTokenTask.Should().ThrowAsync<Exception>();
            testToken.IsRevoked.Should().BeTrue();
        }

        [Fact]
        public async Task Is_RevokeTokenAsync_revoke_token_when_refresh_is_active_one()
        {
            string testRefreshToken = Guid.NewGuid().ToString("N");
            User testUser = new("testLogin", "testPassword", "testSalt", "testmail@gmail.com");
            Token testToken = new(DateTime.Now.AddDays(5), testUser);
            RevokeTokenDto testModel = new()
            {
                RefreshToken = testRefreshToken
            };

            _tokenRepositoryMock.Setup(x => x.GetAsync(testRefreshToken))
                .ReturnsAsync(() => testToken);

            Func<Task> revokeTokenTask = () => _service.RevokeTokenAsync(testModel);
            await revokeTokenTask.Should().NotThrowAsync<Exception>();
            testToken.IsRevoked.Should().BeTrue();
        }
    }
}
