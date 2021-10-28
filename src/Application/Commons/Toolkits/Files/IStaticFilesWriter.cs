using Application.Commons.Types;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Application.Commons.Toolkits.Files
{
    public interface IStaticFilesWriter<T> where T : IStaticFile
    {
        public Task SaveAsync(IFormFile file, string fileName);
    }
}
