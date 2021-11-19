using Application.Commons.Identity;
using Microsoft.AspNetCore.Http;
using System;

namespace Infrastructure.Identity
{
    public sealed class UserProvider : IUserProvider
    {
        public Guid CurrentUserId { get; }

        public UserProvider(IHttpContextAccessor accessor)
        {
            CurrentUserId = accessor.HttpContext.User?.Identity.IsAuthenticated == true
                ? Guid.Parse(accessor.HttpContext.User.Identity.Name)
                : Guid.Empty;
        }
    }
}
