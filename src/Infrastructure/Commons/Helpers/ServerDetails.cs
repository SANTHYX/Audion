using Application.Commons.Helpers;
using Microsoft.AspNetCore.Http;
using System;

namespace Infrastructure.Commons.Helpers
{
    public class ServerDetails : IServerDetails
    {
        private readonly IHttpContextAccessor _accessor;

        public ServerDetails(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Uri GetServerURL()
        {
            var request = _accessor.HttpContext.Request;

            return new($"{ request.Scheme }://{ request.Host.ToUriComponent() }");
        }
    }
}
