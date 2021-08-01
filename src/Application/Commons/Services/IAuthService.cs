using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface IAuthService
    {
        Task RegisterAsync();
        Task LoginAsync();
    }
}
