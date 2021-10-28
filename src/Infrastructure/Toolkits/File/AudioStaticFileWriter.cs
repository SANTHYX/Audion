using Application.Commons.Toolkits.Files;
using Application.Commons.Types;
using Infrastructure.Commons.Helpers;
using Infrastructure.Commons.Toolkits;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Toolkits.File
{
    public class AudioStaticFileWriter : StaticFileWriter, IStaticFilesWriter<IAudioFile>
    {
        public override async Task SaveAsync(IFormFile file, string fileName)
        {
            var directory = DirectoriesStore.AudioStoreDirectory;

            CreateDirectoryIfNotExist(directory);

            var path = Path.Combine(directory,fileName);

            NotEmpty(file);
            ValidFileType(file);

            await base.SaveAsync(file, path);
        }

        protected override void ValidFileType(IFormFile file)
        {
            if (Path.GetExtension(file.FileName) is not ".mp3" or ".wav")
            {
                throw new Exception("Not supported image file, service accept only '.jpg' files");
            }
        }
    }
}
