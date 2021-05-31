using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenueBandManagement
{
    public class Venue
    {
        public string Name;
        public List<Band> bands = new List<Band>();
 
        public void AddBand()
        {
            Console.WriteLine("What is the name of the band to be added?\n");
            var name = Console.ReadLine();
            AddBand(name);
        }

        public void AddBand(string name)
        {
            var band = new Band { Name = name };
            bands.Add(band);
            Console.WriteLine(band.Name + " was added to the list of bands");
        }

        public bool ManageBand()
        {
            if (bands.Count == 0)
            {
                Console.WriteLine("There are currently no bands to manage");
                return true;
            }
            else
            {
                Console.WriteLine("Type the name of the Band you would like to manage.\nThe options are: ");
                foreach (var band in bands)
                {
                    Console.WriteLine(band.Name);
                }
                Console.WriteLine(" ");
                string bandName = Console.ReadLine();
                var bandToManage = CheckBand(bandName);
                if (bandToManage == null)
                {
                    Console.WriteLine("Invalid Command, please provide valid band name.");
                    return true;
                }
                else
                {
                    bool flag = true;
                    do
                    {
                        flag = BandMenuOptionSelection(BandMenuOptions(bandToManage.Name), bandToManage);
                    }
                    while (flag == true);

                }
                return true;
            }
        }

        public Band CheckBand(string name)
        {
            foreach (var band in bands)
            {
                if (band.Name == name)
                {
                    var bandToManage = band;
                    return bandToManage;
                }
            }
            return null;
        }

        public string BandMenuOptions(string bandName)
        {
            while (true)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Managing Band {0}", bandName);
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Type 'Add' to add a musician");
                Console.WriteLine("Type 'Announce' to Announce musicians");
                Console.WriteLine("Type 'Back' to go back to the main menu\n");
                var action = Console.ReadLine();
                return action;
            }
        }

        public bool BandMenuOptionSelection(string action, Band band)
        {
            if (action == "Add")
            {
                band.AddMusician();
            }
            else if (action.StartsWith("Add"))
            {
                var arguments = action.Split(' ');
                if (arguments.Length == 3)
                {
                    band.AddMusician(arguments[1], arguments[2]);
                }
                else
                {
                    band.AddMusician();
                }
            }
            else if (action == "Announce")
            {
                band.Announce();
            }
            else if (action == "Back")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid Command, please provide an action.");
            }
            return true;
        }

        public void Announce()
        {
            switch(bands.Count)
            {
                case var c when c > 5:
                    Console.WriteLine("We have a fantastic line up tonight.");
                    Console.WriteLine(" ");
                    break;
                case var c when c == 2:
                    Console.WriteLine("We have these two great bands tonight.");
                    Console.WriteLine(" ");
                    break;
                case var c when c == 1:
                    Console.WriteLine("Tonight we have the amazing!");
                    Console.WriteLine(" ");
                    break;
                case var c when c == 0:
                    Console.WriteLine("No bands playing tonight.");
                    break;
            }
            foreach (var band in bands)
            {
                Console.WriteLine(band.Name);
            }
        }

    }
}
