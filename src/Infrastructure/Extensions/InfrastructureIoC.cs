using Application.Commons.Helpers;
using Application.Commons.Identity;
using Core.Commons.Identity;
using Core.Commons.Persistance;
using Infrastructure.Commons.Helpers;
using Infrastructure.Commons.Persistance;
using Infrastructure.Extensions.Modules;
using Infrastructure.Identity;
using Infrastructure.Options;
using Infrastructure.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Infrastructure.Extensions
{
    public static class InfrastructureIoC
    {
        public static void AddInfrastructureIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SecuritySettings>(configuration.GetSection(SecuritySettings.Section));
            services.Configure<MailingBotSettings>(configuration.GetSection(MailingBotSettings.Section));
            services.Configure<SmtpOptions>(configuration.GetSection(SmtpOptions.Section));

            services.AddDatabaseModule(configuration);
            services.AddAuthenticationModule(configuration);
            services.AddMailingModule(configuration);

            services.Scan(scn => scn.FromApplicationDependencies()
            .AddRepositoriesModule()
            .AddStaticFileManagersModule()
            .AddPagedResponsesModule());

            services.AddSingleton<IEncryptor, Encryptor>();
            services.AddSingleton<IJwtHandler, JwtHandler>();
            services.AddSingleton<IServerDetails, ServerDetails>();
            services.AddSingleton<IRecoveryIdentityStorage, RecoveryIdentityStorage>();
            services.AddSingleton<ICollection<RecoveryIdentity>, Collection<RecoveryIdentity>>();
            services.AddScoped<IUserProvider, UserProvider>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
