using System.Threading.Tasks;

namespace Application.Commons.Toolkits.Mail
{
    public interface IMailSender
    {
        Task SendTemplatedEmailAsync<T>(string templateName, string targetEmail, string subject, T model);
        Task SendEmailAsync<T>(string targetEmail, string subject, string body);
    }
}
