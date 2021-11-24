using Infrastructure.Commons.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Commons.Toolkits
{
    public abstract class StaticFileManager
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

        public virtual void Remove(string fileId)
        {
            var rootDirectory = DirectoriesStore.AudioStoreDirectory;
            var fileDirectory = Path.Combine(rootDirectory, fileId);

            CheckDirectoryExistance(fileDirectory);

            Directory.Delete(fileDirectory);
        }

        protected virtual void ValidFileType(IFormFile file)
        {
            throw new NotImplementedException();
        }

        protected void NotEmpty(IFormFile file)
        {
            if (file is null)
            {
                throw new Exception("Missing file");
            }
        }

        protected void CheckDirectoryExistance(string directory)
        {
            if (!Directory.Exists(directory))
            {
                throw new Exception("Directory not exists");
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
