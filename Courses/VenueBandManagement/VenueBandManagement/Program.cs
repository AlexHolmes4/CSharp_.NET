using System;
using System.Collections.Generic;

namespace VenueBandManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            EventCompany company = new EventCompany { Name = "Alex's" };
            company.WelcomeMessage();

            while (true) // selection 'Quit' exits program. 
            {
                var action = EventCompanyMenuOptions(company.Name);
                EventCompanyMenuOptionSelection(action, company);
            }
        }
 
        static string EventCompanyMenuOptions(string companyName)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Managing {0} Events", companyName);
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Type 'Add' to add a venue");
            Console.WriteLine("Type 'Manage' to manage venues");
            Console.WriteLine("Type 'Quit' to quit the program\n");
            var action = Console.ReadLine();
            return action;
        }
        static void EventCompanyMenuOptionSelection(string action, EventCompany company)
        {
            if (action == "Add")
            {
                company.AddVenue();
            }
            else if (action.StartsWith("Add"))
            {
                var arguments = action.Split(' ');
                if (arguments.Length == 2)
                {
                    company.AddVenue(arguments[1]);
                }
                else
                {
                    company.AddVenue();
                }
            }
            else if (action == "Manage")
            {
                company.ManageVenue();
            }
            else if (action == "Quit")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid Command, please provide an action");
            }
        }
    }
}
