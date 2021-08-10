using System.IO.Abstractions;
using System.Threading.Tasks;

namespace Application.Commons.Toolkits
{
    public interface IFileManager
    {
        Task SaveFileAsync(IFile file);
    }
}
