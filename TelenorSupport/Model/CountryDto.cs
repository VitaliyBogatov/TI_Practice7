using System;
using TelenorSupport.Model;

namespace TelenorSupport
{
    public class CountryDto : IDto<CountryDto>
    {
        public string Name { get; set; }
        public bool IsTelenorSupported { get; set; }
        public CountryDto(){ }
        public CountryDto(string name, bool isSupported)
        {
            Name = name;
            IsTelenorSupported = isSupported;
        }
        public CountryDto GetData(string line)
        {
            string[] value = line.Split(',');
            Name = value[0];
            IsTelenorSupported = Convert.ToBoolean(value[1]);
            return this;
        }
    }
}
