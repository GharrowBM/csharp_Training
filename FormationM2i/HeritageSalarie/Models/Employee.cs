using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageSalarie.Models
{
    internal class Employee
    {
        public int id;
        public string category;
        public string service;
        public string name;
        public decimal salary;
        public static decimal allSalary;
        private static int nbOfEmployees;

        public static int NbOfEmployees { get => nbOfEmployees; set => nbOfEmployees = value; }

        public Employee(int id, string category, string service, string name, decimal salary)
        {
            this.id = id;
            this.category = category;
            this.service = service;
            this.name = name;
            this.salary = salary;
            allSalary += this.salary;
            NbOfEmployees++;
        }

        public Employee()
        {

        }

        public virtual void PrintSalary()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine($"The salary of {this.name} is {this.salary.ToString("C", CultureInfo.CurrentCulture)}");
        }

        public void SetNbOfEmployeeTo(int number)
        {
            nbOfEmployees = number;
        }

        public void SetNbOfEmployeeTo()
        {
            nbOfEmployees = 0;
        }
    }
}
