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
        private string _name;
        private string _surname;
        private CollarColor collarColor;
        private int _age;

        public string Name { get => _name;  }
        public string Surname { get => _surname; set => _surname = value; }
        public CollarColor CollarColor { get => collarColor; set => collarColor = value; }
        public int Age { get => _age;  }

        public Animal(string name, string surname, CollarColor collarColor, int age)
        {
            _name = name;
            _surname = surname;
            this.collarColor = collarColor;
            _age = age;
        }

        public Animal()
        {

        }
    }
}
