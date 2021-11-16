using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace HeritageSalarie.Models
{
    internal class Commercial : Employee 
    {
        public decimal chiffreAffaire;
        public decimal commission;

        public Commercial(int id, string category, string service, string name, decimal salary, decimal chiffreAffaire, decimal commision) : base (id, category, service, name, salary)
        {
            this.chiffreAffaire = chiffreAffaire;
            this.commission = commision /100;
        }

        public override void PrintSalary()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine($"The salary of {this.name} is {(this.salary+this.chiffreAffaire * this.commission).ToString("C", CultureInfo.CurrentCulture)}");
        }
    }
}
