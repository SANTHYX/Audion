using Application.Commons.Toolkits;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Toolkits
{
    public class FileManager : IFileManager
    {
        public async Task SaveAudioFileAsync(IFormFile file)
        {
            await SaveFileAsync(file,"Audio");
        }

        public async Task SaveImageFileAsync(IFormFile file)
        {
            var path = "";
            if (!IsExist(path))
            {
                throw new Exception("File already exist");
            }
            try
            {
                using (FileStream stream = new(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task SaveFileAsync(IFormFile file, string folder)
        {
            var path = "";
            if (!IsExist(path))
            {
                throw new Exception("File already exist");
            }
            try
            {
                using (FileStream stream = new(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool IsExist(string path) => Directory.Exists(path);
    }
}
