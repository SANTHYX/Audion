using Application.Commons.Toolkits.Files;
using Application.Commons.Types;
using Infrastructure.Commons.Helpers;
using Infrastructure.Commons.Toolkits;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Toolkits.File
{
    public class ImageStaticFileWriter : StaticFileWriter, IStaticFilesWriter<IImageFile>
    {
        public override async Task SaveAsync(IFormFile file, string fileName)
        {
            var directory = DirectoriesStore.ImageStoreDirectory;

            CreateDirectoryIfNotExist(directory);

            var path = Path.Combine(directory, fileName);

            NotEmpty(file);
            ValidFileType(file);

            await base.SaveAsync(file, path);
        }

        protected override void ValidFileType(IFormFile file)
        {
            if (Path.GetExtension(file.FileName) is not ".jpg")
            {
                throw new Exception("Not supported image file, service accept only '.jpg' files");
            }
        }

    }
}
