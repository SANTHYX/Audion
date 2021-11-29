using Core.Domain;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace Core.UnitTests.Domain
{
    public class TrackTests
    {
        [Fact]
        public void SetTitle_should_throw_exception_if_argument_value_will_be_empty()
        {
            var track = Mock.Of<Track>(x => x.Id == Guid.NewGuid());

            track.Should().NotBeNull();

            Action setTrackWithNull = () => track.SetTitle(null);
            Action setTrackWithEmptyString = () => track.SetTitle(string.Empty);
            Action setTrackWithOnlySpaces = () => track.SetTitle("      ");

            setTrackWithNull.Should().Throw<ArgumentNullException>();
            setTrackWithEmptyString.Should().Throw<ArgumentNullException>();
            setTrackWithOnlySpaces.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SetTitle_should_set_value_if_argument_wont_be_empty_value()
        {
            var track = Mock.Of<Track>(x => x.Id == Guid.NewGuid());

            track.Should().NotBeNull();

            track.SetTitle("Title");

            track.Title.Should().Be("Title");
        }

        [Fact]
        public void SetTitle_should_return_value_if_argument_will_be_same_as_current_value()
        {
            var track = Mock.Of<Track>(x => x.Id == Guid.NewGuid() && x.Title == "Title");

            track.Should().NotBeNull();

            track.SetTitle("Title");

            track.Title.Should().Be("Title");
        }

        [Fact]
        public void SetTrackId_should_throw_exception_if_argument_value_will_be_empty()
        {
            var track = Mock.Of<Track>(x => x.Id == Guid.NewGuid());

            track.Should().NotBeNull();

            Action setTrackIdWithNull = () => track.SetTrackId(null);
            Action setTrackIdWithEmptyString = () => track.SetTrackId(string.Empty);
            Action setTrackIdWithOnlySpaces = () => track.SetTrackId("      ");

            setTrackIdWithNull.Should().Throw<ArgumentNullException>();
            setTrackIdWithEmptyString.Should().Throw<ArgumentNullException>();
            setTrackIdWithOnlySpaces.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SetTrackId_should_set_value_if_argument_wont_be_empty_value()
        {
            var track = Mock.Of<Track>(x => x.Id == Guid.NewGuid());

            track.Should().NotBeNull();

            track.SetTrackId("Title");

            track.TrackId.Should().Be("Title");
        }

        [Fact]
        public void SetTrackId_should_return_value_if_argument_will_be_same_as_current_value()
        {
            var track = Mock.Of<Track>(x => x.Id == Guid.NewGuid() && x.TrackId == "ExampleTrackId");

            track.Should().NotBeNull();

            track.SetTrackId("ExampleTrackId");

            track.TrackId.Should().Be("ExampleTrackId");
        }

        [Fact]
        public void AddUser_should_throw_exception_when_arguemnt_will_be_null()
        {
            var track = Mock.Of<Track>(x => x.Id == Guid.NewGuid() && x.TrackId == "ExampleTrackId");

            track.Should().NotBeNull();

            Action addUser = () => track.AddUser(null);

            addUser.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddUser_should_set_value_if_argument_will_be_valid_user()
        {
            var track = Mock.Of<Track>(x => x.Id == Guid.NewGuid() && x.TrackId == "ExampleTrackId");

            track.Should().NotBeNull();

            track.AddUser(Mock.Of<User>());

            track.User.Should().NotBeNull();
        }
    }
}
