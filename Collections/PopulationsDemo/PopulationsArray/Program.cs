using System;

namespace PopulationsArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\alexg\Desktop\Code\GitHub\CSharp\Collections\PopulationsDemo\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            Country[] countries = reader.ReadFirstNCountries(10);

            Console.WriteLine("Hightest Population by Countries Data");

            foreach (Country country in countries)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            Console.WriteLine($"There were {countries.Length} countires in the data-set");

        }
    }
}
