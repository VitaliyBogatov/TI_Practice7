using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common
{
    public class PathHelper
    {
        public static string Filename { get; set; }
        public static string Filepath
        {
            get
            {
                string currentFolderPath = Path.GetDirectoryName(Environment.CurrentDirectory);
                DirectoryInfo directory = new DirectoryInfo(currentFolderPath);

                while (directory != null && directory.GetFiles("*.sln").Length == 0)
                {
                    directory = directory.Parent;
                }
                return directory?.FullName ?? string.Empty;
            }
        }

        public static string Fullpath
        {
            get
            {
                string fullPath = Path.Combine(PathHelper.Filepath, "Files", Filename);
                return fullPath;
            }
        }

        public static string GetFullpath(string filename)
        {
            Filename = filename;
            return Fullpath;
        }
    }
}
