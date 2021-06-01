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

            Console.WriteLine("Enter no. of countries to display> ");
            bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);
            if (!inputIsInt || userInput <= 0)
            {
                Console.WriteLine("You must type a positive integer.\nExiting");
                Environment.Exit(0);
            }
            
            Console.WriteLine("Hightest Population by Countries Data");
            int maxToDisplay = userInput;
            int i;
            for (i = 0; i < countries.Count; i++)  // reverse (i = countries.Count - 1; i >= 0; i--)  
            {
                if (i > 0 && (i % maxToDisplay == 0))
                {
                    Console.WriteLine("Hit return to continue, anything else to quit>");
                    if (Console.ReadLine() != "")
                        break;
                }
                Country country = countries[i];
                Console.WriteLine($"{i+1}: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            if (i != countries.Count)
            {
                Console.WriteLine($"There were {countries.Count - i+1} countires remaining in the data-set");
            }
            else
                Console.WriteLine("All countries retrieved.");
        }
    }
}
