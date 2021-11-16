using System;
using System.Globalization;

namespace ExercicePOO02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee empA = new Employee(GetRandomInt(), "Chercheur", "DevOps", "John", (decimal) 26000.0);
            Employee empB = new Employee(GetRandomInt(), "Technicien", "Integration", "Sarah", (decimal) 14000.0);
            Employee empC = new Employee(GetRandomInt(), "Cadre", "Tech Director", "Abbe", (decimal) 40000.0);

            Employee[] employees = new[] { empA, empB, empC };

            foreach (Employee employee in employees)
            {
                employee.PrintSalary();
            }

            Console.WriteLine($"There are {Employee.NbOfEmployees} employees with a total of {Employee.allSalary.ToString("C", CultureInfo.CurrentCulture)}");

            empC.SetNbOfEmployeeTo(666);

            Console.WriteLine($"There are {Employee.NbOfEmployees} employees with a total of {Employee.allSalary.ToString("C", CultureInfo.CurrentCulture)}");

            Console.ReadLine();


        }

        static int GetRandomInt()
        {
            return new Random().Next(0, int.MaxValue);
        }
    }
}
