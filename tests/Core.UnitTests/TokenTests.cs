using Core.Domain;
using Moq;
using Xunit;
using FluentAssertions;
using System;

namespace Core.UnitTests
{
    public class TokenTests
    {
        private readonly Mock<Token> _tokenMock;

        public TokenTests()
        {
            _tokenMock = new();
        }

        [Fact]
        public void Is_RevokeToken_change_value_to_false_when_token_is_not_revoked_yet()
        {
            var tokenObj = _tokenMock.Object;

            tokenObj.RevokeToken();
            tokenObj.IsRevoked.Should().Be(true);
        }

        [Fact]
        public void Is_RevokeToken_throws_exception_when_token_is_already_revoked()
        {
            var tokenObj = _tokenMock.Object;

            tokenObj.RevokeToken();
            Action revokeTokenMethod = () => tokenObj.RevokeToken();
            revokeTokenMethod.Should().Throw<Exception>();
        }
    }
}
