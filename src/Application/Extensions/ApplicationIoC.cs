using Application.Commons.Helpers;
using Application.Commons.Mappers;
using Application.Commons.Services;
using Application.Mappers;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ApplicationIoC
    {
        public static void AddApplicationIoC(this IServiceCollection services)
        {
            services.AddServices();
            services.AddMappers();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        private static void AddMappers(this IServiceCollection services)
        {
            services.AddSingleton<IUserMapper, UserMapper>();
            services.AddSingleton<ITokenMapper, TokenMapper>();
            services.AddSingleton<IPlaylistMapper, PlaylistMapper>();
            services.AddSingleton<ITrackMapper, TrackMapper>();
        }

        private static void AddServices(this IServiceCollection services)
        { 
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IPlaylistService, PlaylistService>();
            services.AddScoped<ITrackService, TrackService>();
        }

    }
}
