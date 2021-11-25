using System.IO.Abstractions;
using System.Threading.Tasks;

namespace Application.Commons.Toolkits.Mail
{
    public interface IMailSender
    {
        Task SendEmailAsync(string email, IFile template);
    }
}
