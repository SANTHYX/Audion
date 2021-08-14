using Application.Commons.Mappers;
using Application.Services;
using Core.Commons.Repositories;
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
            var user = await _service.GetAsync(name); 

            user.Should().BeNull();
        }
    }
}
