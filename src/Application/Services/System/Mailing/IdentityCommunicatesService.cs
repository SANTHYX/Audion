using Application.Commons.Helpers;
using Application.Commons.Services.System.Mailing;
using Application.Commons.Toolkits.Mail;
using Application.Models;
using System;
using System.Threading.Tasks;

namespace Application.Services.System.Mailing
{
    public class IdentityCommunicatesService : IIdentityCommunicatesService
    {
        private readonly IServerDetails _server;
        private readonly IMailSender _sender;

        public IdentityCommunicatesService(IServerDetails server, IMailSender sender)
        {
            _server = server;
            _sender = sender;
        }

        public async Task SendMailWithRecoveryPageLinkAsync(string targetEmail, Guid recoveryThreadId)
        {
            var model = new RecoveryMessageModel { BaseUrl = _server.GetServerURL(), RecoveryId = recoveryThreadId};

            await _sender.SendTemplatedEmailAsync("RecoveryResource.cshtml", 
            targetEmail, "Password recovery", model);
        }
    }
}
