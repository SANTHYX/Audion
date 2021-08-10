using Application.Commons.Toolkits;
using System.IO.Abstractions;
using System.Threading.Tasks;

namespace Infrastructure.Toolkits
{
    public class FileManager : IFileManager
    {
        public Task SaveFileAsync(IFile file)
        {
            throw new System.NotImplementedException();
        }
    }
}
