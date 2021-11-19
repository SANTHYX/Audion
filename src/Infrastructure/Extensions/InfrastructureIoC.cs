using Application.Commons.Helpers;
using Application.Commons.Identity;
using Application.Commons.Toolkits.Files;
using Core.Commons.Pagination;
using Core.Commons.Persistance;
using Core.Commons.Repositories;
using Infrastructure.Commons.Helpers;
using Infrastructure.Commons.Pagination;
using Infrastructure.Commons.Persistance;
using Infrastructure.Identity;
using Infrastructure.Options;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Infrastructure.Extensions
{
    public static class InfrastructureIoC
    {
        public static void AddInfrastructureIoC(this IServiceCollection services, IConfiguration configuration)
        {
            //Infrastructure IoC Container Space
            services.Configure<SecuritySettings>(configuration.GetSection("Security"));

            services.AddDatabaseModule(configuration);
            services.AddAuthenticationModule(configuration);
            services.AddRepositoriesModule();
            services.AddStaticFileWriterModule();

            services.AddSingleton<IEncryptor, Encryptor>();
            services.AddSingleton<IJwtHandler, JwtHandler>();
            services.AddSingleton<IServerDetails, ServerDetails>();
            services.AddSingleton<IUserProvider, UserProvider>();
            services.AddSingleton(typeof(IPagedResponse<>), typeof(PagedResponse<>));
        }

        private static void AddRepositoriesModule(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            services.AddScoped<ITrackRepository, TrackRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void AddDatabaseModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    npgCfg => npgCfg.MigrationsAssembly("Infrastructure"));
                opt.EnableDetailedErrors();
            });

        }

        private static void AddAuthenticationModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration.GetSection("Security:Key").Value)),
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }

        private static void AddStaticFileWriterModule(this IServiceCollection services)
        {
            services.Scan(x => x.FromApplicationDependencies()
                .AddClasses(y => y.AssignableTo(typeof(IStaticFilesWriter<>)))
                .AsImplementedInterfaces()
                .WithSingletonLifetime());
              
        }
    }
}
