using Application.Commons.Toolkits.Mail;
using FluentEmail.Core;
using Infrastructure.Options;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
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

        public async Task SendEmailAsync<T>(string templateName, string targetEmail, string subject, T model) where T : new()
        {
            var mail = _emailFactory.Create()
                .SetFrom(_settings.Address)
                .To(targetEmail)
                .Subject(subject)
                .UsingTemplateFromFile(templateName,model);

            await mail.SendAsync();
        }
    }
}
