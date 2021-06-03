using System;
using System.IO;
using Common;

namespace TelenorSupport
{
    class Program
    {
        static void Main(string[] args)
        {
            SupportHelper support = new SupportHelper();
            string fileName = "TelenorSupport.csv";
            CSVHandler csv = new CSVHandler(fileName);

        Beggin:
            Console.WriteLine("Choose an option." +
                                "\n1.Get telenor supported countries from csv." +
                                "\n2.Add a new country to the supported." +
                                "\n3.Set the country support." +
                                "\n4.Get the supported countries." +
                                "\nOther key to close.");

            Int32.TryParse(Console.ReadLine(), out int option);

            switch (option)
            {
                case 1:
                    csv.ReadFromFile();
                    //support.Countries = csv.ReadData();
                    //csv.Parse();
                    break;
                case 2:
                    support.SetCountrySupport("Ukraine", true);
                    support.GetCountrySupport("Ukraine");
                    support.SetCountrySupport("Denmark", true);
                    support.GetCountrySupport("Denmark");
                    csv.WriteData(support);
                    break;
                case 3:
                    support.SetCountrySupport("Denmark", true);
                    support.SetCountrySupport("Hungary", true);
                    break;
                case 4:
                    support.GetCountrySupport("Denmark");
                    support.GetCountrySupport("Hungary");
                    support.GetCountrySupport("Ukraine");
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
            goto Beggin;
        }
    }
}
