using Application.Commons.Identity;
using Core.Commons.Pagination;
using Core.Commons.Repositories;
using Infrastructure.Commons.Pagination;
using Infrastructure.Identity;
using Infrastructure.Options;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class InfrastructureIoC
    {
        public static void AddInfrastructureIoC(this IServiceCollection services, IConfiguration configuration)
        {
            //Infrastructure IoC Container Space
            services.Configure<SecuritySettings>(configuration.GetSection("Security"));
            services.AddDbContext<DataContext>(opt => 
            {
                opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    npgCfg => npgCfg.MigrationsAssembly("Infrastructure"));
                opt.EnableDetailedErrors();
            });
            services.AddSingleton(typeof(IPagedResponse<>), typeof(PagedResponse<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            services.AddScoped<ITrackRepository, TrackRepository>();
            services.AddSingleton<IEncryptor, Encryptor>();
            services.AddSingleton<IJwtHandler, JwtHandler>();
        }
    }
}
