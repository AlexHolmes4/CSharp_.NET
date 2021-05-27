using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

/*
Purpose of Project is for unit testing only, see CollectionTypesTests proj. 
*/

namespace CollectionTypes
{
    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return String.Equals(x.Name, y.Name);
        }

        public int GetHashCode([DisallowNull] Employee obj)
        {
            return obj.Name.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var departments = new SortedDictionary<string, HashSet<Employee>>();

            departments.Add("Sales", new HashSet<Employee>(new EmployeeComparer()));
            departments["Sales"].Add(new Employee { Name = "Joy" });
            departments["Sales"].Add(new Employee { Name = "Dani" });
            departments["Sales"].Add(new Employee { Name = "Dani" });

            departments.Add("Engineering", new HashSet<Employee>(new EmployeeComparer()));
            departments["Engineering"].Add(new Employee { Name = "Scott" });
            departments["Engineering"].Add(new Employee { Name = "Alex" });
            departments["Engineering"].Add(new Employee { Name = "Dani" });

            foreach (var department in departments)
            {
                Console.WriteLine(department.Key);
                foreach (var employee in department.Value)
                {
                    Console.WriteLine(employee.Name);
                }
            }



        }
    }
}
