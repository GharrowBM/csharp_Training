using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01.Classes
{
    internal class Person
    {
        //public event Action<object, EventArgs> Shout;

        //private event EventHandler _shout;
        //public event EventHandler? Shout
        //{
        //    add { _shout += value; }
        //    remove { _shout -= value; }
        //}

        public event EventHandler? Shout;

        public string Name { get; set; }
        public int AngerLevel;

        public Person(string name, int angerLevel)
        {
            Name = name;
            AngerLevel = angerLevel;
        }


        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                Shout?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Deconstruct(out string name, out int angerLevel)
        {
            name = Name;
            angerLevel = AngerLevel;
        }
    }
}
