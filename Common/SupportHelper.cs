using System;
using System.Collections.Generic;

namespace Common
{
    public class SupportHelper
    {
        public Dictionary<int, Country> Countries { get; set; }

        public void SetCountrySupport(string name, bool isSupported)
        {
            Country country = new Country(name, isSupported);

            if (!Countries.ContainsValue(country))
            {
                int count = 0;
                foreach (var value in Countries)
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
                    Countries.Add(Countries.Count, country);
                }
            }

        }

        public void GetCountrySupport(string name)
        {
            foreach (var country in Countries)
            {
                if (country.Value.Name.Equals(name))
                {
                    Console.WriteLine(country.Value.Name + '-' + country.Value.IsTelenorSupported);
                    break;
                }
            }
        }
    }
}
