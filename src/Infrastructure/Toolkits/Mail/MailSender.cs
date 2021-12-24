using Application.Commons.Toolkits.Mail;
using FluentEmail.Core;
using Infrastructure.Commons.Helpers;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Toolkits.Mail
{
    public class MailSender : IMailSender
    {
        private readonly IFluentEmailFactory _emailFactory;
        private readonly MailingBotSettings _settings;

        public MailSender(IFluentEmailFactory emailFactory, IOptions<MailingBotSettings> settings)
        {
            _emailFactory = emailFactory;
            _settings = settings.Value;
        }
        public async Task SendTemplatedEmailAsync<T>(string templateName, string targetEmail, string subject, T model)
        {
            var templatePath = Path.Combine(DirectoriesStore.EmailTemplatesStoreDirectory, templateName);

            var mail = _emailFactory.Create()
                .SetFrom(_settings.Address)
                .To(targetEmail)
                .Subject(subject)
                .UsingTemplateFromFile(templatePath, model);

            await mail.SendAsync();
        }

        public async Task SendEmailAsync<T>(string targetEmail, string subject, string body)
        {
            var mail = _emailFactory.Create()
                .SetFrom(_settings.Address)
                .To(targetEmail)
                .Subject(subject)
                .Body(body);

            await mail.SendAsync();
        }

    }
}
