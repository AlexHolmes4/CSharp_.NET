using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public string Name
        {
            get;
            set;
        }

        public NamedObject(string name)
        {
            Name = name;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded; 
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
        
    }

    public class DiscBook : Book
    {
        
        public DiscBook(string name) : base(name)
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
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    result.Add(double.Parse(line));
                }
                return result;
            }
        }
    }


    public class InMemoryBook : Book
    {
        private List<double> grades;

        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        
        public override event GradeAddedDelegate GradeAdded;

        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;              
                default:
                    AddGrade(0);
                    break;
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }


        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            for (var index = 0; index < grades.Count; index++)
            {
                result.Add(grades[index]);
            }
            return result;
        }        
    }
}
