using System.Threading.Tasks;

namespace Application.Commons.Toolkits.Mail
{
    public interface IMailSender
    {
        Task SendEmailAsync<T>(string templateName, string targetEmail, string subject, T model);
    }
}
