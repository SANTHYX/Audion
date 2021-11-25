using Application.Commons.Toolkits.Mail;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using System.IO.Abstractions;
using System.Threading.Tasks;

namespace Infrastructure.Toolkits.Mail
{
    public class MailSender : IMailSender
    {
        private readonly MailingBotSettings _settings;

        public MailSender(IOptions<MailingBotSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendEmailAsync(string targetMail, IFile template)
        {
            throw new System.NotImplementedException();
        }
    }
}
