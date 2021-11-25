﻿using System;
using System.IO;

namespace Infrastructure.Commons.Helpers
{
    public static class DirectoriesStore
    {
        public static string ImageStoreDirectory => Path.Combine(LibraryDirectory,"Files","Images");
        public static string AudioStoreDirectory => Path.Combine(LibraryDirectory, "Files", "Audio");
        public static string EmailTemplatesStoreDirectory => Path.Combine(LibraryDirectory, "Files", "Templates");
        private static string LibraryDirectory 
            => Path.Combine(Directory.GetParent(Environment.CurrentDirectory).ToString(),"Infrastructure");
    }
}
