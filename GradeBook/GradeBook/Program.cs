using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //var book = new InMemoryBook("Alex's Book");
            //book.GradeAdded += OnGradeAdded;

            //EnterGrades(book);

            //var stats = book.GetStatistics();

            //Console.WriteLine($"For the book named {book.Name}");
            //Console.WriteLine($"The lowest grade is {stats.Low}");
            //Console.WriteLine($"The highest grade is {stats.High}");
            //Console.WriteLine($"The average grade is {stats.Average:N2}");
            //Console.WriteLine($"The letter grade is {stats.Letter}");

            var book = new DiscBook("Alex's Disc Book");
            EnterGrades(book);
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade  or 'q' to quit");
                string input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    double grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
