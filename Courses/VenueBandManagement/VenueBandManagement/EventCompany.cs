using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenueBandManagement
{
    public class EventCompany
    {
        public string Name;
        public List<Venue> venues = new List<Venue>();

        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome {0}.", Name);
        }

        public void AddVenue()
        {
            Console.WriteLine("What is the name of the venue to be added?\n");
            var name = Console.ReadLine();
            AddVenue(name);
        }

        public void AddVenue(string name)
        {
            var venue = new Venue { Name = name };
            venues.Add(venue);
            Console.WriteLine(venue.Name + " was added to the list of venues");
        }

        public void ManageVenue()
        {
            if (venues.Count == 0)
            {
                Console.WriteLine("There are currently no venues to manage");
            }
            else
            {
                Console.WriteLine("Type the name of the Venue you would like to manage.\nThe options are: ");
                foreach (var venue in venues)
                {
                    Console.WriteLine(venue.Name);
                }
                string venueName = Console.ReadLine();
                var venueToManage = CheckVenue(venueName);
                if (venueToManage == null)
                {
                    Console.WriteLine("Invalid Command, please provide valid venue name.");
                }
                else
                {
                    bool flag = true;
                    do
                    {
                        flag = VenueMenuOptionSelection(VenueMenuOptions(venueToManage.Name), venueToManage);
                    }
                    while (flag == true);
                }
            }
        }

        public Venue CheckVenue(string name)
        {
            foreach (var venue in venues)
            {
                if (venue.Name == name)
                {
                    var venueToManage = venue;
                    return venueToManage;
                }   
            }
            return null;
        }

        public string VenueMenuOptions(string venueName)
        {
            while (true)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Managing Venue {0}", venueName);
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Type 'Add' to add a band");
                Console.WriteLine("Type 'Announce' to Announce bands");
                Console.WriteLine("Type 'Manage' to manage a band");
                Console.WriteLine("Type 'Back' to go back to the main menu\n");
                var action = Console.ReadLine();
                return action;
            }
        }

        public bool VenueMenuOptionSelection(string action, Venue venue)
        {
            if (action == "Add")
            {
                venue.AddBand();
            }
            else if (action.StartsWith("Add"))
            {
                var arguments = action.Split(' ');
                if (arguments.Length == 2)
                {
                    venue.AddBand(arguments[1]);
                }
                else
                {
                    venue.AddBand();
                }
            }
            else if (action == "Announce")
            {
                venue.Announce();
            }
            else if (action == "Manage")
            {
                venue.ManageBand();
            }
            else if (action == "Back")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid Command, please provide an action");
            }
            return true;
        }
    }
}
