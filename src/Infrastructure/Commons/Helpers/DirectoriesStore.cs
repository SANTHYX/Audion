using System;
using System.IO;

namespace Infrastructure.Commons.Helpers
{
    public static class DirectoriesStore
    {
        public static string ImageStoreDirectory => Path.Combine(FilesStoreDirectory, "Images");
        public static string AudioStoreDirectory => Path.Combine(FilesStoreDirectory, "Audio");
        public static string EmailTemplatesStoreDirectory => Path.Combine(LibraryDirectory, "Templates");
        public static string FilesStoreDirectory => Path.Combine(LibraryDirectory, "Files");
        private static string LibraryDirectory
            => Path.Combine(Directory.GetParent(Environment.CurrentDirectory).ToString(), "Infrastructure");
    }
}
