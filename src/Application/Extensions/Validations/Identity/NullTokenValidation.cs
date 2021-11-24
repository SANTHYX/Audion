using Core.Commons.Identity;
using System;

namespace Application.Extensions.Validations.Identity
{
    public static class NullTokenValidation
    {
        public static Token NotNull(this Token token)
        {
            if (token is null)
            {
                throw new UnauthorizedAccessException("Invalid creedentials");
            }

            return token;
        }
    }
}
