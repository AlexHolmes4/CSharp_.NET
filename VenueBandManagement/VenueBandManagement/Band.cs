using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenueBandManagement
{
    public class Band
    {
        public List<Musician> musicians = new List<Musician>();
        public string Name;
        public void AddMusician()
        {
            Console.WriteLine("What is the name of the musician to be added?\n");
            var name = Console.ReadLine();
            Console.WriteLine("What instruement does " + name + " play?\n");
            var instrument = Console.ReadLine();
            AddMusician(name, instrument);
        }

        public void AddMusician(string name, string instruement)
        {
            var musician = new Musician { Name = name, Instrument = instruement };
            musicians.Add(musician);
            Console.WriteLine(musician.Name + " was added.\n");
        }

        public void Announce()
        {
            foreach (var musician in musicians)
            {
                Console.WriteLine("Welcome " + musician.Name + " to the stage!");
            }
            Console.WriteLine(" ");
        }
    }
}
