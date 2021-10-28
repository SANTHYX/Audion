﻿using Application.Commons.Identity;
using Application.Commons.Toolkits.Files;
using Application.Commons.Types;
using Core.Commons.Pagination;
using Core.Commons.Persistance;
using Core.Commons.Repositories;
using Infrastructure.Commons.Pagination;
using Infrastructure.Commons.Persistance;
using Infrastructure.Identity;
using Infrastructure.Options;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Repositories;
using Infrastructure.Toolkits.File;
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

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            services.AddScoped<ITrackRepository, TrackRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IEncryptor, Encryptor>();
            services.AddSingleton<IJwtHandler, JwtHandler>();
            services.AddSingleton(typeof(IPagedResponse<>), typeof(PagedResponse<>));
            services.AddSingleton(typeof(IStaticFilesWriter<IImageFile>), typeof(ImageStaticFileWriter));
            services.AddSingleton(typeof(IStaticFilesWriter<IAudioFile>), typeof(AudioStaticFileWriter));
        }
    }
}
