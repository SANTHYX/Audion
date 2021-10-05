using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Application.Commons.Toolkits
{
    public interface IFileManager
    {
        Task SaveAudioFileAsync(IFormFile file);
        Task SaveImageFileAsync(IFormFile file);
        bool IsExist(string path);
    }
}
