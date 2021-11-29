using Core.Domain;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace Core.UnitTests.Domain
{
    public class PlaylistTests
    {
        [Fact]
        public void SetName_should_throw_exception_if_argument_value_will_be_empty()
        {
            var playlist = Mock.Of<Playlist>(x => x.Id == Guid.NewGuid());

            playlist.Should().NotBeNull();

            Action setNameWithNull = () => playlist.SetName(null);
            Action setNameWithEmptyString = () => playlist.SetName(string.Empty);
            Action setNameWithOnlySpaces = () => playlist.SetName("      ");

            setNameWithNull.Should().Throw<ArgumentNullException>();
            setNameWithEmptyString.Should().Throw<ArgumentNullException>();
            setNameWithOnlySpaces.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SetName_should_set_value_if_argument_wont_be_empty_value()
        {
            var playlist = Mock.Of<Playlist>(x => x.Id == Guid.NewGuid());

            playlist.Should().NotBeNull();

            playlist.SetName("Name");

            playlist.Name.Should().Be("Name");
        }

        [Fact]
        public void SetName_should_return_value_if_argument_will_be_same_as_current_value()
        {
            var playlist = Mock.Of<Playlist>(x => x.Id == Guid.NewGuid() && x.Name == "Name");

            playlist.Should().NotBeNull();

            playlist.SetName("Name");

            playlist.Name.Should().Be("Name");
        }

        [Fact]
        public void AddUser_should_throw_exception_when_arguemnt_will_be_null()
        {
            var playlist = Mock.Of<Playlist>(x => x.Id == Guid.NewGuid());

            playlist.Should().NotBeNull();

            Action addUser = () => playlist.AddUser(null);

            addUser.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddUser_should_set_value_if_argument_will_be_valid_user()
        {
            var playlist = Mock.Of<Playlist>(x => x.Id == Guid.NewGuid());

            playlist.Should().NotBeNull();

            playlist.AddUser(Mock.Of<User>());

            playlist.User.Should().NotBeNull();
        }
    }
}
