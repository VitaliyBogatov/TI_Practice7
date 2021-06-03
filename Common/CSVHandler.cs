using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common
{
    public class CSVHandler
    {
        public int Length { get; set; }
        public string Filename { get; set; }
        public string Filepath {
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
        public string Fullpath
        {
            get
            {
                string filePath = Path.Combine(Filepath, "Files", Filename);
                return filePath;
            }
        }
        public CSVHandler(string fileName)
        {
            Filename = fileName;
        }

        public IEnumerable<string> Data { get; set; }

        public void ReadFromFile()
        {
            if (File.Exists(Fullpath))
            {
                using (StreamReader streamReader = File.OpenText(Fullpath))
                {
                    string line = string.Empty;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }

        public void Parse()
        {
            using FileStream fileStream = File.OpenRead(Fullpath);
            Console.WriteLine(fileStream.ToString());
        }


        public Dictionary<int, Country> ReadData()
        {
            int index = 0;
            Dictionary<int, Country> dictionary = new Dictionary<int, Country>();
            foreach (string row in Data)
            {
                string[] columns = row.Split(',');
                string name = Convert.ToString(columns[0]);
                bool isTelenorSupported = Convert.ToBoolean(columns[1]);
                Country country = new Country(name, isTelenorSupported);
                dictionary.Add(index, country);
                index++;
            }
            return dictionary;
        }

        public void WriteData(SupportHelper support)
        {
            if (File.Exists(Filepath))
            {
                foreach (string row in Data)
                {
                    string[] columns = row.Split(',');
                    string name = Convert.ToString(columns[0]);
                    bool isSupported = Convert.ToBoolean(columns[1]);

                    foreach (var value in support.Countries)
                    {
                        if (value.Value.Name.Equals(name) && !value.Value.IsTelenorSupported.Equals(isSupported))
                        {
                            File.AppendAllText(Filepath, "y,z");

                        }
                    }
                }
            }
        }

        //string value;
        //string name = country.Name;
        //string isSupported = country.IsTelenorSupported.ToString();
        //line[0] = name + "," + isSupported;

        //File.AppendAllText(filePath, line);

        //string[] line = new string[1];
        //string name = country.Name;
        //string isSupported = country.IsTelenorSupported.ToString();
        //line[0] = name + "," + isSupported;
        //File.AppendAllLines(filePath, line);
    }
}
