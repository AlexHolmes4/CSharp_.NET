using System;
using System.Collections.Generic;

namespace PopulationsDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\alexg\Desktop\Code\GitHub\CSharp\Collections\PopulationsDemo\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            Dictionary<string, Country> countries = reader.ReadAllCountries();

            Console.WriteLine("Which country do you want to look up?");
            string userInput = Console.ReadLine();
            bool foundCountry = countries.TryGetValue(userInput, out Country country);
            if (!foundCountry)
            {
                Console.WriteLine($"Sorry, there is no country with code, {userInput}");
            }
            else
                Console.WriteLine($"{country.Name} has population {PopulationFormatter.FormatPopulation(country.Population)}");
        }
    }
}
