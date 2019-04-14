

using MyCookBook.Interfaces;
using System;
using System.IO;

namespace MyCookBook.iOS.Services
{
        public class FileHelper : IFileHelper
        {
            public string GetLocalFilePath(string filename)
            {
                string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

                if (!Directory.Exists(libFolder))
                {
                    Directory.CreateDirectory(libFolder);
                }

                return Path.Combine(libFolder, filename);
            }
        }
    
}