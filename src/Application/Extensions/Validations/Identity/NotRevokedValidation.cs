using Core.Commons.Identity;
using System;

namespace Application.Extensions.Validations.Identity
{
    public static class NotRevokedValidation
    {
        public static Token NotRevoked(this Token token)
        {
            if (token.IsRevoked)
            {
                throw new Exception("Token is revoked, cannot be refreshed");
            }

            return token;
        }
    }
}
