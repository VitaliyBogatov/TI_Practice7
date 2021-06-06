using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TelenorSupport
{
    public class SupportHelper
    {
        Dictionary<int, CountryDto> countriesDictionary = new Dictionary<int, CountryDto>();
        //public Dictionary<int, CountryDto> Countries { get; set; }

        public void SetCountryDetails(string name, bool isSupported)
        {
            CountryDto country = new CountryDto(name, isSupported);

            if (countriesDictionary.Count != 0 && !countriesDictionary.ContainsValue(country))
            {
                int count = 0;
                foreach (var value in countriesDictionary)
                {
                    if (value.Value.Name.Equals(name))
                    {
                        value.Value.IsTelenorSupported = isSupported;
                        count++;
                        break;
                    }
                }
                if (count == 0)
                {
                    countriesDictionary.Add(countriesDictionary.Count, country);
                }
            }
            else { countriesDictionary.Add(countriesDictionary.Count, country); }
        }

        public string GetCountryDetails(string name)
        {
            foreach (var country in countriesDictionary)
            {
                if (country.Value.Name.Equals(name))
                {
                    return country.Value.Name + '-' + country.Value.IsTelenorSupported;
                }
            }
            return "Country is absent.";
        }
        public void GetCountriesListAsTable(List<CountryDto> countries)
        {
            ConsoleTable table = new ConsoleTable();
            {
                bool headersExist = true;
                if (headersExist)
                {
                    List<string> headers = new List<string>();
                    foreach (PropertyInfo prop in typeof(CountryDto).GetProperties())
                    {
                        headers.Add(prop.Name);
                    }
                    table.AddColumn(headers);
                    headersExist = false;
                }
                foreach (var country in countries)
                {
                    table.AddRow(country.Name, country.IsTelenorSupported.ToString());
                }
            }
            table.Write();
        }
        public List<CountryDto> GetCountriesList()
        {
            return countriesDictionary.Values.ToList();
        }
        public List<CountryDto> GetCountriesListBySupport(bool isSupported)
        {
            return countriesDictionary.Values.Where(country => country.IsTelenorSupported.Equals(isSupported)).ToList();
        }
    }
}
