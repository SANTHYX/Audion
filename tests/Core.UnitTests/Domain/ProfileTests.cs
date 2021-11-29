using Core.Domain;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace Core.UnitTests.Domain
{
    public class ProfileTests
    {
        [Fact]
        public void SetFirstName_should_set_any_values_even_when_argument_will_be_empty()
        {
            var profile = Mock.Of<Profile>(x => x.Id == Guid.NewGuid());

            profile.Should().NotBeNull();

            profile.SetFirstName(string.Empty);
            profile.FirstName.Should().Be(string.Empty);

            profile.SetFirstName("   ");
            profile.FirstName.Should().Be("   ");

            profile.SetFirstName("Jan");
            profile.FirstName.Should().Be("Jan");
        }

        [Fact]
        public void SetFirstName_should_return_if_argument_value_will_be_same_as_current()
        {
            var profile = Mock.Of<Profile>(x => x.Id == Guid.NewGuid() && x.FirstName == "Kris");

            profile.Should().NotBeNull();

            profile.SetFirstName("Kris");
            
            profile.FirstName.Should().Be("Kris");
        }

        [Fact]
        public void SetLastName_should_set_any_values_even_when_argument_will_be_empty()
        {
            var profile = Mock.Of<Profile>(x => x.Id == Guid.NewGuid());

            profile.Should().NotBeNull();

            profile.SetLastName(string.Empty);
            profile.LastName.Should().Be(string.Empty);

            profile.SetLastName("   ");
            profile.LastName.Should().Be("   ");

            profile.SetLastName("Jan");
            profile.LastName.Should().Be("Jan");
        }

        [Fact]
        public void SetLastName_should_return_if_argument_value_will_be_same_as_current()
        {
            var profile = Mock.Of<Profile>(x => x.Id == Guid.NewGuid() && x.LastName == "Janczak");

            profile.Should().NotBeNull();

            profile.SetLastName("Janczak");

            profile.LastName.Should().Be("Janczak");
        }

        [Fact]
        public void SetCity_should_set_any_values_even_when_argument_will_be_empty()
        {
            var profile = Mock.Of<Profile>(x => x.Id == Guid.NewGuid());

            profile.Should().NotBeNull();

            profile.SetCity(string.Empty);
            profile.City.Should().Be(string.Empty);

            profile.SetCity("   ");
            profile.City.Should().Be("   ");

            profile.SetCity("Jan");
            profile.City.Should().Be("Jan");
        }

        [Fact]
        public void SetCity_should_return_if_argument_value_will_be_same_as_current()
        {
            var profile = Mock.Of<Profile>(x => x.Id == Guid.NewGuid() && x.City == "Warsaw");

            profile.Should().NotBeNull();

            profile.SetCity("Warsaw");

            profile.City.Should().Be("Warsaw");
        }

        [Fact]
        public void SetCountry_should_set_any_values_even_when_argument_will_be_empty()
        {
            var profile = Mock.Of<Profile>(x => x.Id == Guid.NewGuid());

            profile.Should().NotBeNull();

            profile.SetCountry(string.Empty);
            profile.Country.Should().Be(string.Empty);

            profile.SetCountry("   ");
            profile.Country.Should().Be("   ");

            profile.SetCountry("Jan");
            profile.Country.Should().Be("Jan");
        }

        [Fact]
        public void SetCountry_should_return_if_argument_value_will_be_same_as_current()
        {
            var profile = Mock.Of<Profile>(x => x.Id == Guid.NewGuid() && x.Country == "Poland");

            profile.Should().NotBeNull();

            profile.SetCountry("Poland");

            profile.Country.Should().Be("Poland");
        }

        [Fact]
        public void SetImageId_should_throw_exception_if_argument_value_will_be_null()
        {
            var profile = Mock.Of<Profile>(x => x.Id == Guid.NewGuid());

            profile.Should().NotBeNull();

            Action setImageWithNull = () => profile.SetImage(null);
            Action setImageWithOnlySpace = () => profile.SetImage("       ");
            Action setImageWithEmptyString = () => profile.SetImage(string.Empty);

            setImageWithNull.Should().Throw<ArgumentNullException>();
            setImageWithOnlySpace.Should().Throw<ArgumentNullException>();
            setImageWithEmptyString.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SetImageId_should_return_when_argument_is_same_as_current_value()
        {
            var profile = Mock.Of<Profile>(x => x.Id == Guid.NewGuid() && x.ImageId == "ImageId");

            profile.Should().NotBeNull();

            profile.SetImage("ImageId");

            profile.ImageId.Should().Be("ImageId");
        }

        [Fact]
        public void SetImageId_should_set_value_when_argument_is_not_null()
        {
            var profile = Mock.Of<Profile>(x => x.Id == Guid.NewGuid());

            profile.Should().NotBeNull();

            profile.SetImage("anyImageId");

            profile.ImageId.Should().Be("anyImageId");
        }

        [Fact]
        public void AddUser_should_throw_exception_if_argument_value_will_be_null()
        {
            var profile = Mock.Of<Profile>(x => x.Id == Guid.NewGuid());

            profile.Should().NotBeNull();

            Action addUser = () => profile.AddUser(null);

            addUser.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddUser_should_set_value_when_argument_is_not_null()
        {
            var profile = Mock.Of<Profile>(x => x.Id == Guid.NewGuid());

            profile.Should().NotBeNull();

            profile.AddUser(Mock.Of<User>(x => x.Id == Guid.NewGuid()));

            profile.User.Should().NotBeNull();
        }
    }
}
