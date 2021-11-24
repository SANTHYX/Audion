using Application.Commons.Types;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Application.Commons.Toolkits.Files
{
    public interface IStaticFileManager<T> where T : IStaticFile
    {
        public Task SaveAsync(IFormFile file, string fileName);
        public void Remove(string fileId);
    }
}
