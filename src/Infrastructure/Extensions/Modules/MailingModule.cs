using Application.Commons.Toolkits.Mail;
using Infrastructure.Commons.Helpers;
using Infrastructure.Toolkits.Mail;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.Modules
{
    public static class MailingModule
    {
        public static void AddMailingModule(this IServiceCollection service)
        {
            service.AddFluentEmail("audion@service.com")
                .AddRazorRenderer(DirectoriesStore.EmailTemplatesStoreDirectory);

            service.AddScoped<IMailSender, MailSender>();
        }
    }
}
