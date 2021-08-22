using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Application.Commons.Toolkits
{
    public interface IFileManager
    {
        Task SaveFileAsync(IFormFile file);
    }
}
