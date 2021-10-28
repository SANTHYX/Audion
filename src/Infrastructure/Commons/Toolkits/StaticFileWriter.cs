using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Commons.Toolkits
{
    public abstract class StaticFileWriter
    {
        public virtual async Task SaveAsync(IFormFile file, string path)
        {
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

        protected virtual void ValidFileType(IFormFile file)
        {
            //Method that should be override
        }

        protected void NotEmpty(IFormFile file)
        {
            if (file is null)
            {
                throw new Exception("Missing file");
            }
        }

        protected void CreateDirectoryIfNotExist(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
