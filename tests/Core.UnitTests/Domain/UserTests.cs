using Core.Domain;
using Moq;
using System;
using Xunit;
using FluentAssertions;

namespace Core.UnitTests.Domain
{
    public class UserTests
    {
        [Fact]
        public void SetUsername_should_throw_exception_when_argument_will_be_empty_value()
        {
            var user = Mock.Of<User>(x => x.Id == Guid.NewGuid());

            user.UserName.Should().BeNull();

            Action setUsername = () => user.SetUserName(string.Empty);

            user.Should().NotBeNull();
            user.UserName.Should().BeNull();
            setUsername.Should().Throw<ArgumentNullException>();
        }
        
        [Fact]
        public void SetUsername_should_throw_exception_when_argument_will_be_empty_spaces()
        {
            var user = Mock.Of<User>(x => x.Id == Guid.NewGuid());

            user.UserName.Should().BeNull();

            Action setUsername = () => user.SetUserName("        ");

            user.Should().NotBeNull();
            user.UserName.Should().BeNull();
            user.UserName.Should().NotBe("        ");
            setUsername.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SetUsername_should_set_value_if_argument_will_be_not_empty_string()
        {
            var user = Mock.Of<User>(x => x.Id == Guid.NewGuid());

            user.UserName.Should().BeNull();

            user.SetUserName("testUserName");

            user.Should().NotBeNull();
            user.UserName.Should().NotBeNull();
            user.UserName.Should().Be("testUserName");
        }

        [Fact]
        public void SetUsername_should_return_if_argument_value_will_be_same_as_property()
        {
            var user = Mock.Of<User>(x => x.Id == Guid.NewGuid() && x.UserName == "testName");

            user.UserName.Should().NotBeNullOrWhiteSpace();

            user.SetUserName("testName");

            user.Should().NotBeNull();
            user.UserName.Should().Be("testName");
        }

        [Fact]
        public void SetPassword_should_throw_exception_when_argument_will_be_empty_value()
        {
            var user = Mock.Of<User>(x => x.Id == Guid.NewGuid());

            user.Password.Should().BeNull();

            Action setPassword = () => user.SetPassword(string.Empty);

            user.Should().NotBeNull();
            user.Password.Should().BeNull();
            setPassword.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SetPassword_should_throw_exception_when_argument_will_be_empty_spaces()
        {
            var user = Mock.Of<User>(x => x.Id == Guid.NewGuid());

            user.Password.Should().BeNull();

            Action setPassword = () => user.SetPassword("        ");

            user.Should().NotBeNull();
            setPassword.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SetPassword_should_set_value_if_argument_will_be_not_empty_string()
        {
            var user = Mock.Of<User>(x => x.Id == Guid.NewGuid());

            user.Password.Should().BeNull();

            user.SetPassword("testUserName");

            user.Should().NotBeNull();
            user.Password.Should().NotBeNull();
            user.Password.Should().Be("testUserName");
        }

        [Fact]
        public void SetPassword_should_return_if_argument_value_will_be_same_as_property()
        {
            var user = Mock.Of<User>(x => x.Id == Guid.NewGuid() && x.Password == "testPassword");

            user.Password.Should().NotBeNullOrWhiteSpace();

            user.SetPassword("testPassword");

            user.Should().NotBeNull();
            user.Password.Should().Be("testPassword");
        }


        [Fact]
        public void SetSalt_should_throw_exception_when_argument_will_be_empty_value()
        {
            var user = Mock.Of<User>(x => x.Id == Guid.NewGuid());

            user.Salt.Should().BeNull();

            Action setSalt = () => user.SetSalt(string.Empty);

            user.Should().NotBeNull();
            user.Salt.Should().BeNull();
            setSalt.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SetSalt_should_throw_exception_when_argument_will_be_empty_spaces()
        {
            var user = Mock.Of<User>(x => x.Id == Guid.NewGuid());

            user.Salt.Should().BeNull();

            Action setSalt = () => user.SetSalt("        ");

            user.Should().NotBeNull();
            setSalt.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SetSalt_should_set_value_if_argument_will_be_not_empty_string()
        {
            var user = Mock.Of<User>(x => x.Id == Guid.NewGuid());

            user.Salt.Should().BeNull();

            user.SetSalt("testSalt");

            user.Should().NotBeNull();
            user.Salt.Should().NotBeNull();
            user.Salt.Should().Be("testSalt");
        }

        [Fact]
        public void SetSalt_should_return_if_argument_value_will_be_same_as_property()
        {
            var user = Mock.Of<User>(x => x.Id == Guid.NewGuid() && x.Salt == "testSalt");

            user.Salt.Should().NotBeNullOrWhiteSpace();

            user.SetSalt("testSalt");

            user.Should().NotBeNull();
            user.Salt.Should().Be("testSalt");
        }

        [Fact]
        public void SetEmail_should_throw_exception_when_argument_will_be_empty_value()
        {
            var user = Mock.Of<User>(x => x.Id == Guid.NewGuid());

            user.Email.Should().BeNull();

            Action setEmail = () => user.SetEmail(string.Empty);

            user.Should().NotBeNull();
            user.Email.Should().BeNull();
            setEmail.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SetEmail_should_throw_exception_when_argument_will_be_empty_spaces()
        {
            var user = Mock.Of<User>(x => x.Id == Guid.NewGuid());

            user.Email.Should().BeNull();

            Action setEmail = () => user.SetEmail("        ");

            user.Should().NotBeNull();
            setEmail.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SetEmail_should_throw_exception_when_argument_will_not_be_valid_mail()
        {
            var user = Mock.Of<User>(x => x.Id == Guid.NewGuid());

            user.Email.Should().BeNull();

            Action setEmail = () => user.SetEmail("testMail111mail.com");

            user.Should().NotBeNull();
            setEmail.Should().Throw<Exception>();
        }

        [Fact]
        public void SetEmail_should_set_value_if_argument_will_be_not_empty_string()
        {
            var user = Mock.Of<User>(x => x.Id == Guid.NewGuid());

            user.Email.Should().BeNull();

            user.SetEmail("testMail@gmail.com");

            user.Should().NotBeNull();
            user.Email.Should().NotBeNull();
            user.Email.Should().Be("testMail@gmail.com");
        }

        [Fact]
        public void SetEmail_should_return_if_argument_value_will_be_same_as_property()
        {
            var user = Mock.Of<User>(x => x.Id == Guid.NewGuid() && x.Email == "testEmail@gmail.com");

            user.Email.Should().NotBeNullOrWhiteSpace();

            user.SetEmail("testEmail@gmail.com");

            user.Should().NotBeNull();
            user.Email.Should().Be("testEmail@gmail.com");
        }
    }
}
