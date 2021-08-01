using Microsoft.AspNetCore.Builder;
using Web.Middleware;

namespace Web.Extensions
{
    public static class ExceptionExtension
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
            => app.UseMiddleware(typeof(ExceptionsMiddleware));
    }
}
