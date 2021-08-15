using Core.Domain;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace Core.UnitTests
{
    public class ProfileTests
    {
        private readonly Mock<Profile> _profileMock;

        public ProfileTests()
        {
            _profileMock = new();
        }

        [Fact]
        public void Is_SetFirstName_sets_value_if_arg_is_empty_string()
        {
            string testValue = string.Empty;
            var profileObj = _profileMock.Object;

            profileObj.SetFirstName(testValue);
            profileObj.FirstName.Should().Be(testValue);
        }

        [Fact]
        public void Is_SetFirstName_sets_value_if_arg_is_expected_string()
        {
            string testValue = "Maria";
            var profileObj = _profileMock.Object;

            profileObj.SetFirstName(testValue);
            profileObj.FirstName.Should().Be(testValue);
        }

        [Fact]
        public void Is_SetLastName_sets_value_if_arg_is_empty_string()
        {
            string testValue = string.Empty;
            var profileObj = _profileMock.Object;

            profileObj.SetLastName(testValue);
            profileObj.LastName.Should().Be(testValue);
        }

        [Fact]
        public void Is_SetLastName_sets_value_if_arg_is_expected_string()
        {
            string testValue = "Jakubiak";
            var profileObj = _profileMock.Object;

            profileObj.SetLastName(testValue);
            profileObj.LastName.Should().Be(testValue);
        }

        [Fact]
        public void Is_SetCountry_sets_value_if_arg_is_empty_string()
        {
            string testValue = string.Empty;
            var profileObj = _profileMock.Object;

            profileObj.SetCountry(testValue);
            profileObj.Country.Should().Be(testValue);
        }

        [Fact]
        public void Is_SetCountry_sets_value_if_arg_is_expected_string()
        {
            string testValue = "Polska";
            var profileObj = _profileMock.Object;

            profileObj.SetCountry(testValue);
            profileObj.Country.Should().Be(testValue);
        }

        [Fact]
        public void Is_SetCity_sets_value_if_arg_is_empty_string()
        {
            string testValue = string.Empty;
            var profileObj = _profileMock.Object;

            profileObj.SetCity(testValue);
            profileObj.City.Should().Be(testValue);
        }

        [Fact]
        public void Is_SetCity_sets_value_if_arg_is_expected_string()
        {
            string testValue = "Krakow";
            var profileObj = _profileMock.Object;

            profileObj.SetCity(testValue);
            profileObj.City.Should().Be(testValue);
        }

        [Fact]
        public void Is_AddUser_throws_exception_when_arg_user_is_null()
        {
            User user = null;
            var profileObj = _profileMock.Object;

            Action addUserMethod = () => profileObj.AddUser(user);
            addUserMethod.Should().Throw<Exception>();
        }

        [Fact]
        public void Is_AddUser_sets_when_arg_user_is_valid_user_object()
        {
            var user = new Mock<User>();
            var profileObj = _profileMock.Object;

            profileObj.AddUser(user.Object);
            profileObj.User.Should().NotBeNull();
        }
    }
}
