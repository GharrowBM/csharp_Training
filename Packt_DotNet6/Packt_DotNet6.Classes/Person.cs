using Packt_DotNet6.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Packt_DotNet6.Classes
{
    public class Person
    {
        private string _name;
        private DateTime _dateOfBirth;
        private FavoriteWonders _favoriteWonders;
        private List<Person> _children;
        private int _angerLevel;

        public string Name { get => _name; }
        public DateTime DateOfBirth { get => _dateOfBirth; }
        public FavoriteWonders FavoriteWonders { get => _favoriteWonders; set => _favoriteWonders = value; }
        public List<Person> Children { get => _children; }

        public event Action Shout;
        //public event EventHandler? Shout;
        public Person()
        {
            _children = new List<Person>();
        }
        public Person(string name, DateTime dateOfBirth) : this()
        {
            string nameRegexp = @"^\w$";

            if (Regex.IsMatch(name, nameRegexp))
            {
                _name = name;
            }
            else
            {
                throw new InvalidNameException("Ce nom n'est pas bon !");
            }

            _dateOfBirth = dateOfBirth;
        }

        public void Deconstruct(out string name, out DateTime dob)
        {
            name = _name;
            dob = _dateOfBirth;
        }

        public void Deconstruct(out string name, out DateTime dob, out FavoriteWonders favWonder)
        {
            name = _name;
            dob = _dateOfBirth;
            favWonder = _favoriteWonders;
        }

        public void Poke()
        {
            _angerLevel++;

            if (_angerLevel >= 3) Shout?.Invoke();
        }

        public void PassingParameters(int x, ref int y, out int z)
        {
            // les paramètres OUT ne peuvent avoir une valeur par défaut
            // ET ils doivent être initialisés dans la méthode
            z = 99;

            // Incrémentation de chaque paramètre
            x++;
            y++;
            z++;
        }
    }
}
