using Application.Commons.Toolkits;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Toolkits
{
    public class FileManager : IFileManager
    {
        public async Task SaveFileAsync(IFormFile file)
        {
            var path = "";
            try
            {
                using (FileStream stream = new(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
