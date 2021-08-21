using Application.Dto.Profile;
using Application.Services;
using Core.Commons.Repositories;
using Core.Domain;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

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
            _httpContextAccessorMock = new();
            _httpContextAccessorMock.Setup(x => x.HttpContext.User.Identity.IsAuthenticated);
            _loggerMock = new();
            _userRepositoryMock = new();
            _profileRepositoryMock = new();      
            _service = new(_loggerMock.Object, _userRepositoryMock.Object, 
                _profileRepositoryMock.Object, _httpContextAccessorMock.Object);
        }

        [Fact]
        public async Task Is_CreateAsync_throws_exception_when_we_creating_profile_for_not_existing_user()
        {
            CreateProfileDto testModel = new()
            {
                City = "Warsaw",
                Country = "Poland",
                FirstName = "Zygfryd",
                LastName = "Brzęczyszczykiewicz"
            };

            _userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(() => null);

            Func<Task> createAsyncTask = () => _service.CreateAsync(testModel);
            await createAsyncTask.Should().ThrowAsync<Exception>()
                .WithMessage("Invalid creedentials");
        }

        [Fact]
        public async Task Is_CreateAsync_throws_exception_when_user_try_to_create_another_profile_instance()
        {
            CreateProfileDto testModel = new()
            {
                City = "Warsaw",
                Country = "Poland",
                FirstName = "Zygfryd",
                LastName = "Brzęczyszczykiewicz"
            };;

            _userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(Mock.Of<User>(x => x.Profile == Mock.Of<Profile>()));

            Func<Task> createAsyncTask = () => _service.CreateAsync(testModel);
            await createAsyncTask.Should().ThrowAsync<Exception>();
        }

        [Fact]
        public async Task Is_CreateAsync_should_pass_when_user_dont_have_any_profile()
        {
            CreateProfileDto testModel = new()
            {
                City = "Warsaw",
                Country = "Poland",
                FirstName = "Zygfryd",
                LastName = "Brzęczyszczykiewicz"
            }; ;

            _userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(Mock.Of<User>(x => x.Profile == null));

            Func<Task> createAsyncTask = () => _service.CreateAsync(testModel);
            await createAsyncTask.Should().NotThrowAsync<Exception>();
        }
    }
}
