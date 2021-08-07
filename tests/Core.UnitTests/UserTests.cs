using Core.Domain;
using Moq;
using Xunit;

namespace Core.UnitTests
{
    public class UserTests
    {
        private readonly Mock<User> _user;

        public UserTests()
        {
            _user = new();
        }

        [Fact]
        public void Is_SetUserName_throws_exception_where_passed_value_is_empty_string()
        {

        }
    }
}
