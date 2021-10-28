using Core.Commons.Types;
using System;

namespace Core.Domain
{
    public class Token : IEntity
    {
        public string RefreshToken { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public bool IsRevoked { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        protected Token() { }

        public Token(DateTime expiresAt, User user)
        {
            RefreshToken = Guid.NewGuid().ToString("N");
            CreatedAt = DateTime.UtcNow;
            ExpiresAt = expiresAt;
            IsRevoked = false;
            User = user ?? throw new Exception("Cannot generate token for non existing user");
        }

        public void RevokeToken()
        {
            if (IsRevoked)
            {
                throw new Exception("Token is already revoked");
            }

            IsRevoked = true;
        }
    }
}
