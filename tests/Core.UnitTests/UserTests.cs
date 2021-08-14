using Core.Domain;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace Core.UnitTests
{
    public class UserTests
    {
        private readonly Mock<User> _userMock;

        public UserTests()
        {
            _userMock = new();
        }

        [Fact]
        public void Is_SetUserName_throws_exception_where_passed_value_is_empty_string()
        {
            string userName = string.Empty;
            var userObj = _userMock.Object;

            Action setUserNameMethod = () => userObj.SetUserName(userName);

            setUserNameMethod.Should().Throw<ArgumentNullException>();
            userObj.UserName.Should().BeNull();
        }

        [Fact]
        public void Is_SetUserName_throws_exception_where_passing_only_whiteSpaces()
        {
            string userName = "                         ";
            var userObj = _userMock.Object;

            Action settingUser = () => userObj.SetUserName(userName);

            settingUser.Should().Throw<ArgumentNullException>();
            userObj.UserName.Should().BeNull();
        }

        [Fact]
        public void Is_SetUserName_setting_value_if_will_be_expected_value_passed()
        {
            string userName = "Jack";
            var userObj = _userMock.Object;

            userObj.SetUserName(userName);

            userObj.UserName.Should().NotBeNullOrEmpty();
            userObj.UserName.Should().Be("Jack");
        }

        [Fact]
        public void Is_SetUserName_wont_change_value_if_passing_one_will_be_same_as_current()
        {
            string userName = "Jack";
            string nextName ="Jack";
            var userObj = _userMock.Object;

            userObj.SetUserName(userName);
            userObj.UserName.Should().Be(userName);

            userObj.SetUserName(nextName);
            userObj.UserName.Should().Be(nextName);
        }

        [Fact]
        public void Is_SetPassword_throws_exception_when_passed_value_is_empty()
        {
            string password = string.Empty;
            var userObj = _userMock.Object;

            Action setUserPasswordMethod = () => userObj.SetPassword(password);
            setUserPasswordMethod.Should().Throw<ArgumentNullException>();
            userObj.Password.Should().BeNull();
        }

        [Fact]
        public void Is_SetPassword_setting_password_if_value_will_be_expected_value()
        {
            string password = "passowrd";
            var userObj = _userMock.Object;

            userObj.SetPassword(password);
            userObj.Password.Should().Be(password);
        }

        [Fact]
        public void Is_SetEmail_throws_exception_if_value_will_be_empty_string()
        {
            string email = string.Empty;
            var userObj = _userMock.Object;

            Action setEmailMethod = () => userObj.SetEmail(email);
            setEmailMethod.Should().Throw<ArgumentNullException>();
            userObj.Email.Should().BeNull();
        }

        [Fact]
        public void Is_SetEmail_throws_exception_if_value_will_not_be_mail()
        {
            string email = "testvalue.com";
            var userObj = _userMock.Object;

            Action setEmailMethod = () => userObj.SetEmail(email);
            setEmailMethod.Should().Throw<Exception>();
            userObj.Email.Should().BeNull();
        }

        [Fact]
        public void Is_SetEmail_set_value_that_is_expected_email()
        {
            string email = "testvalue@x.com";
            var userObj = _userMock.Object;

            userObj.SetEmail(email);
            userObj.Email.Should().Be(email);
        }

        [Fact]
        public void Is_SetSalt_throws_exception_when_salt_will_be_empty_string()
        {
            string salt = string.Empty;
            var userObj = _userMock.Object;

            Action setSaltMethod = () => userObj.SetSalt(salt);
            setSaltMethod.Should().Throw<ArgumentNullException>();
            userObj.Salt.Should().BeNull();
        }

        [Fact]
        public void Is_SetSalt_set_value_that_is_expected_as_correct_one()
        {
            string salt = "dWQT2!%!4r!%TT#!%!";
            var userObj = _userMock.Object;

            userObj.SetSalt(salt);

            userObj.Salt.Should().Be(salt);
        }
    }
}
