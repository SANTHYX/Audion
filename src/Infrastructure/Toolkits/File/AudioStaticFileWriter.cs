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

            var filename = $"{fileName}.{Path.GetExtension(file.FileName)}";
            var path = Path.Combine(directory, filename);

            NotEmpty(file);
            ValidFileType(file);

            await base.SaveAsync(file, path);
        }

        protected override void ValidFileType(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);

            if (extension != ".mp3" && extension != ".wav")
            {
                throw new Exception("Not supported audio file, service accept only '.wav' or '.mp3' files");
            }
        }
    }
}
