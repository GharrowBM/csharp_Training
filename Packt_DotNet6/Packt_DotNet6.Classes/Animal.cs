using Packt_DotNet6.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt_DotNet6.Classes
{
    public class Animal
    {

        public string Name { get; init; }
        public string Surname { get; set; }
        public CollarColor CollarColor { get; set; }
        public int Age { get; init; }

        public Animal(string name, string surname, CollarColor collarColor, int age)
        {
            Name = name;
            Surname = surname;
            CollarColor = collarColor;
            Age = age;
        }

        public Animal()
        {

        }

        public override string ToString()
        {
            return $"{Name} a comme surnom {Surname}, {Age} ans et un collier comportant les couleurs : {CollarColor}";
        }
    }
}
