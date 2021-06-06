using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Common;
using TelenorSupport.Model;

namespace TelenorSupport
{
    public class CSVHandler
    {
        public static List<T> ReadData<T>(string fileName, bool header) where T : IDto<T>, new()
        {
            List<T> data = new List<T>();
            using StreamReader streamReader = File.OpenText(PathHelper.GetFullpath(fileName));
            {
                bool headersExist = header;
                while (!streamReader.EndOfStream)
                {
                    if (!headersExist)
                    {
                        T t = new T();
                        T line = t.GetData(streamReader.ReadLine());
                        data.Add(line);
                    }
                    else
                    {
                        streamReader.ReadLine();
                        headersExist = false;
                    }
                }
            }
            return data;
        }

        public static void WriteData(SupportHelper countries, string fileName, bool header)
        {
            string[] value = new string[2];
            using StreamWriter streamWriter = new StreamWriter(PathHelper.GetFullpath(fileName));
            {
                bool headersExist = header;
                if (headersExist)
                {
                    List<string> headers = new List<string>();
                    foreach (PropertyInfo prop in typeof(CountryDto).GetProperties())
                    {
                        headers.Add(prop.Name);
                    }
                    streamWriter.WriteLineAsync(String.Join(",", headers));
                    headersExist = false;
                }
                foreach (var country in countries.GetCountriesList())
                {
                    value[0] = country.Name;
                    value[1] = country.IsTelenorSupported.ToString();
                    streamWriter.WriteLineAsync(String.Join(",", value));
                }
            }
        }
    }
}
