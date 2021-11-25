using Application.Commons.Helpers;
using Core.Commons.Persistance.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Infrastructure.Files.Templates
{
    public class RecoveryResourceModel : PageModel
    {
        private readonly IRecoveryIdentityRepository _recovery;
        private readonly IServerDetails _serverDetails;

        public RecoveryResourceModel(IRecoveryIdentityRepository recovery, IServerDetails serverDetails)
        {
            _recovery = recovery;
            _serverDetails = serverDetails;
        }

        public void OnGet()
        {
            ViewData["Url"] = $"{_serverDetails.GetServerURL()}/recovery-password/Id";
        }
    }
}
