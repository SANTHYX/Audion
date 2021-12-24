using Application.Commons.Toolkits.Mail;
using Infrastructure.Options;
using Infrastructure.Toolkits.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.Extensions.Modules
{
    public static class MailingModule
    {
        public static void AddMailingModule(this IServiceCollection service, IConfiguration configuration)
        {
            var option = configuration.GetSection(SmtpOptions.Section).Get<SmtpOptions>();

            service.AddFluentEmail("audion.service.bot@gmail.com")
                .AddRazorRenderer()
                .AddSmtpSender(new SmtpClient(option.Server)
                {
                    Port = option.Port,
                    EnableSsl = option.UseSSL,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(option.User, option.Password)
                });

            service.AddScoped<IMailSender, MailSender>();
        }
    }
}
