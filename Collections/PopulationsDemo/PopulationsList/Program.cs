using System;
using System.Collections.Generic;

namespace PopulationsList
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\alexg\Desktop\Code\GitHub\CSharp\Collections\PopulationsDemo\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            List<Country> countries = reader.ReadAllCountries();

            Console.WriteLine("Hightest Population by Countries Data");
            for (int i = 0; i < countries.Count; i++)
            {
                Country country = countries[i];
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            Console.WriteLine($"There were {countries.Count} countires in the data-set");
        }
    }
}
