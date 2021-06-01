using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsOfCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\alexg\Desktop\Code\GitHub\CSharp\Collections\PopulationsDemo\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            Dictionary<string, List<Country>> countries = reader.ReadAllCountries();
            foreach (string region in countries.Keys)
                Console.WriteLine(region);

            Console.WriteLine("Which of the above regions do you want? ");
            string chosenRegion = Console.ReadLine();

            if (countries.ContainsKey(chosenRegion))
            {
                foreach (Country country in countries[chosenRegion].OrderBy(x => x.Name).Take(10))
                    Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            else
                Console.WriteLine("That is not a valid region");
        }
    }
}
