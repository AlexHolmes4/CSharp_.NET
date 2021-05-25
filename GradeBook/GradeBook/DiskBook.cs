using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {

        public DiskBook(string name) : base(name)
        {
            Name = name;
        }

        public override event GradeAddedDelegate GradeAdded;
        public override void AddGrade(double grade)
        {
            using (StreamWriter writer = File.AppendText($"{Name}.txt"))
            {
                if (grade <= 100 && grade >= 0)
                {
                    writer.WriteLine(grade);
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
                else
                {
                    throw new ArgumentException($"Invalid {nameof(grade)}");
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (StreamReader reader = File.OpenText($"{Name}.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    result.Add(double.Parse(line));
                }
                return result;
            }
        }
    }
}
