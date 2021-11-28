using Application.Commons.Types;
using System;
using System.Threading.Tasks;

namespace Application.Commons.Services.System.Mailing
{
    public interface IIdentityCommunicatesService : IService
    {
        Task SendMailWithRecoveryPageLinkAsync(string email, Guid recoveryThreadId);
    }
}
