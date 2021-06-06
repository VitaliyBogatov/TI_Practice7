using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Common;
using ConsoleTables;

namespace TelenorSupport
{
    class Program
    {
        static void Main(string[] args)
        {
            SupportHelper support = new SupportHelper();
            List<CountryDto> csvData;
            PathHelper.Filename = "TelenorSupport.csv";
            bool isHeaderExist = true;

        Beggin:
            Console.WriteLine("Choose an option." +
                                "\n1.Get telenor supported countries from csv." +
                                "\n2.Add a new country to the supported." +
                                "\n3.Set the country support." +
                                "\n4.Get a supported country details." +
                                "\n5.Get ALL supported countries." +
                                "\n6.Get the supported/unsupported countries." +
                                "\nOther key to close.");

            Int32.TryParse(Console.ReadLine(), out int option);
            switch (option)
            {
                case 1:
                    csvData = CSVHandler.ReadData<CountryDto>(PathHelper.Filename,isHeaderExist);
                    foreach (CountryDto country in csvData)
                    {
                        support.SetCountryDetails(country.Name, country.IsTelenorSupported);
                    }
                    Console.WriteLine();
                    break;
                case 2:
                    support.SetCountryDetails("Ukraine", true);
                    Console.WriteLine();
                    break;
                case 3:
                    support.SetCountryDetails("Denmark", true);
                    support.SetCountryDetails("Hungary", true);
                    CSVHandler.WriteData(support, PathHelper.Filename, isHeaderExist);
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine(support.GetCountryDetails("Denmark"));
                    Console.WriteLine(support.GetCountryDetails("Hungary"));
                    Console.WriteLine(support.GetCountryDetails("Ukraine"));
                    Console.WriteLine();
                    break;
                case 5:
                    support.GetCountriesListAsTable(support.GetCountriesList());
                    Console.WriteLine();
                    break;
                case 6:
                    support.GetCountriesListAsTable(support.GetCountriesListBySupport(true));
                    Console.WriteLine();
                    support.GetCountriesListAsTable(support.GetCountriesListBySupport(false));
                    Console.WriteLine();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
            goto Beggin;
        }
    }
}
