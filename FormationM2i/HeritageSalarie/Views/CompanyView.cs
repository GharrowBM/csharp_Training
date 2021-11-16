using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeritageSalarie.Models;

namespace HeritageSalarie.Views
{
    internal class CompanyView
    {
        private Employee[] employees;
        public CompanyView()
        {
            Employee e1 = new Employee(1, "Technicien", "Dev", "John", 25000m);
            Employee e2 = new Employee(2, "Cadre", "Management", "Mark", 50000m);
            Employee e3 = new Employee(3, "Chercheur", "Reseau", "Elliot", 35000m);
            Commercial c1 = new Commercial(4, "Vendeur", "Informatique", "Sarah", 20000m, 10000m, 25m);
            Commercial c2 = new Commercial(5, "Vendeur", "Informatique", "Patrick", 20000m, 5000m, 25m);

            this.employees = new Employee[20];

            employees[0] = e1;
            employees[1] = e2;
            employees[2] = e3;
            employees[3] = c1;
            employees[4] = c2;
        }

        public void AddEmployee(Employee e)
        {
           employees[Array.FindIndex(employees, x => x == null)] = e;
        } 

        public void RemoveEmployee(Employee e)
        {
            employees[Array.FindIndex(employees, x => x == e)] = new Employee();
        }

        public void UpdateEmployee(Employee oldEmployee, Employee newEmployee)
        {
            employees[Array.FindIndex(employees, x => x == oldEmployee)] = newEmployee;
        }


    }
}
