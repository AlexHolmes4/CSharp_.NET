using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

/*
Purpose of Project is for unit testing only, see CollectionTypesTests proj. 
*/

namespace CollectionTypes
{
    

    class Program
    {
        static void Main(string[] args)
        {
            var departments = new DepartmentCollection();

            departments.Add("Sales", new Employee { Name = "Joy" })
                       .Add("Sales", new Employee { Name = "Ben" })
                       .Add("Sales", new Employee { Name = "Ben" });

            departments.Add("Engineering", new Employee { Name = "Scott" })
                       .Add("Engineering", new Employee { Name = "Alex" })
                       .Add("Engineering", new Employee { Name = "Dani" });

            foreach (var department in departments)
            {
                Console.WriteLine(department.Key);
                foreach (var employee in department.Value)
                {
                    Console.WriteLine(employee.Name);
                }
                Console.WriteLine("\n");
            }



        }
    }
}
