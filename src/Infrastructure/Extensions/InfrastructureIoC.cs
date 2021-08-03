using Infrastructure.Options;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public class InfrastructureIoC
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
        }
    }
}
