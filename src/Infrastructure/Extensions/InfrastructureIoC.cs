using Application.Commons.Identity;
using Core.Commons.Repositories;
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
        public static void AddInfrastructureIoC(IServiceCollection services, IConfiguration configuration)
        {
            //Infrastructure IoC Container Space
            services.Configure<SecuritySettings>(configuration.GetSection("Security"));
            services.AddDbContext<DataContext>(opt => 
            {
                opt.UseNpgsql(configuration.GetConnectionString(""),
                    npgCfg => npgCfg.MigrationsAssembly("Infrastructure"));
                opt.EnableDetailedErrors();
            });
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
