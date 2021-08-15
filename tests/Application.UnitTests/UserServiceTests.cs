using Application.Commons.Mappers;
using Application.Dto.User;
using Application.Services;
using Core.Commons.Repositories;
using Core.Domain;
using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _repositoryMock;
        private readonly Mock<IUserMapper> _mapperMock;
        private readonly UserService _service;

        public UserServiceTests()
        {
            _repositoryMock = new();
            _mapperMock = new();
            _service = new (_repositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetAsync_returns_null_when_user_not_exist()
        {
            string name = "Jacck2344";

            _repositoryMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(() => null);
            _mapperMock.Setup(x => x.MapTo(null))
                .Returns(()=> null);

            var user = await _service.GetAsync(name); 

            user.Should().BeNull();
        }

        [Fact]
        public async Task GetAsync_returns_user_when_passing_userName_of_existing_one()
        {
            string userName = "MikeRipper";
            string password = "anypassword";
            string salt = "anySalt";
            string email = "string1@gmail.com";

            User testUser = new(userName, password, salt, email);

            _repositoryMock.Setup(x => x.GetAsync(userName))
                .ReturnsAsync(testUser);
            _mapperMock.Setup(x => x.MapTo(testUser))
                .Returns(new GetUserDto
            {
                 UserName = userName,
                 Email = "string1@gmail.com"
            });

            var user = await _service.GetAsync(userName);
            user.Should().NotBeNull();
            user.UserName.Should().Be(userName);
        }
    }
}
