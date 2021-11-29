using Core.Domain;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace Core.UnitTests.Domain
{
    public class CommentTests
    {
        [Fact]
        public void SetText_should_throw_exception_if_argument_value_will_be_empty()
        {
            var comment = Mock.Of<Comment>(x => x.Id == Guid.NewGuid());

            comment.Should().NotBeNull();

            Action setTextWithNull = () => comment.SetText(null);
            Action setTextWithEmptyString = () => comment.SetText(string.Empty);
            Action setTextWithOnlySpaces = () => comment.SetText("      ");

            setTextWithNull.Should().Throw<ArgumentNullException>();
            setTextWithEmptyString.Should().Throw<ArgumentNullException>();
            setTextWithOnlySpaces.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SetText_should_set_value_if_argument_wont_be_empty_value()
        {
            var comment = Mock.Of<Comment>(x => x.Id == Guid.NewGuid());

            comment.Should().NotBeNull();

            comment.SetText("Title");

            comment.Text.Should().Be("Title");
        }

        [Fact]
        public void SetText_should_return_value_if_argument_will_be_same_as_current_value()
        {
            var comment = Mock.Of<Comment>(x => x.Id == Guid.NewGuid() && x.Text == "Text");

            comment.Should().NotBeNull();

            comment.SetText("Text");

            comment.Text.Should().Be("Text");
        }
    }
}
