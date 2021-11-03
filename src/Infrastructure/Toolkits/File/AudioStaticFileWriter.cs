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
    public class AudioStaticFileWriter : StaticFileWriter, IStaticFilesWriter<IAudioFile>
    {
        public override async Task SaveAsync(IFormFile file, string fileName)
        {
            var directory = DirectoriesStore.AudioStoreDirectory;

            CreateDirectoryIfNotExist(directory);

            var newFileName = $"{fileName}{Path.GetExtension(file.FileName)}";
            var path = Path.Combine(directory, newFileName);

            NotEmpty(file);
            ValidFileType(file);

            await base.SaveAsync(file, path);
        }

        protected override void ValidFileType(IFormFile file)
        {
            if (Path.GetExtension(file.FileName) is not ".mp3" and not ".wav")
            {
                throw new InvalidFileFormatException("Not supported audio file, service accept only '.wav' or '.mp3' files");
            }
        }
    }
}
