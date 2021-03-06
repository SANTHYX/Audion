using Application.Commons.Toolkits.Files;
using Application.Commons.Types;
using Infrastructure.Commons.Helpers;
using Infrastructure.Commons.Toolkits;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Toolkits.File
{
    public class ImageStaticFileManager : StaticFileManager, IStaticFileManager<IImageFile>
    {
        public override async Task SaveAsync(IFormFile file, string fileName)
        {
            var directory = DirectoriesStore.ImageStoreDirectory;

            CreateDirectoryIfNotExist(directory);

            NotEmpty(file);
            ValidFileType(file);

            var newFileName = $"{ fileName }{ Path.GetExtension(file.FileName) }";
            var path = Path.Combine(directory, newFileName);

            await base.SaveAsync(file, path);
        }

        protected override void ValidFileType(IFormFile file)
        {
            if (Path.GetExtension(file.FileName) is not ".jpg")
            {
                throw new InvalidFileFormatException("Not supported image file, service accept only '.jpg' files");
            }
        }

    }
}
