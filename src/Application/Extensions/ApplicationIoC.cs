using Application.Extensions.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ApplicationIoC
    {
        public static void AddApplicationIoC(this IServiceCollection services)
        {
            services.Scan(scn => scn.FromApplicationDependencies()
            .AddMappers()
            .AddServices());

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
