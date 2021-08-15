using Core.Domain;
using Moq;
using Xunit;
using FluentAssertions;
using System;

namespace Core.UnitTests
{
    public class PlaylistTests
    {
        private readonly Mock<Playlist> _playlistMock;

        public PlaylistTests()
        {
            _playlistMock = new();
        }

        [Fact]
        public void Is_SetName_throwing_exception_when_arg_value_is_empty()
        {
            string testValue = string.Empty;
            var playlistObj = _playlistMock.Object;

            Action setNameMethod = () => playlistObj.SetName(testValue);
            setNameMethod.Should().Throw<ArgumentNullException>();
            playlistObj.Name.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Is_SetName_throwing_exception_when_arg_value_is_only_spaces()
        {
            string testValue = "          ";
            var playlistObj = _playlistMock.Object;

            Action setNameMethod = () => playlistObj.SetName(testValue);
            setNameMethod.Should().Throw<ArgumentNullException>();
            playlistObj.Name.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Is_SetName_set_expected_arg_value()
        {
            string testValue = "Hardcore/Hiphop 2k21";
            var playlistObj = _playlistMock.Object;

            playlistObj.SetName(testValue);
            playlistObj.Name.Should().Be(testValue);
        }

        [Fact]
        public void Is_AddUser_throws_exception_if_arg_value_is_null()
        {
            User user = null;
            var playlistObj = _playlistMock.Object;

            Action addUserMethod = () => playlistObj.AddUser(user);
            addUserMethod.Should().Throw<Exception>();
            playlistObj.User.Should().BeNull();
        }

        [Fact]
        public void Is_AddUser_set_value_if_its_expected_arguement_value()
        {
            User user = new Mock<User>().Object;
            var playlistObj = _playlistMock.Object;

            playlistObj.AddUser(user);
            playlistObj.User.Should().NotBeNull();
        }
    }
}
