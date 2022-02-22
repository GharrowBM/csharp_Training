using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01.Classes
{
    internal abstract class Mammal
    {
        private int _nbOfCells; 

        public int NbOfCells { get => _nbOfCells; }

        public Mammal(int nbOfCells)
        {
            _nbOfCells = nbOfCells;
        }

        public Mammal()
        {
            _nbOfCells = new Random().Next();
        }

        public virtual string Move(string wayOfMoving = "Swimming")
        {
            return $"This {this.GetType().Name} moves with : {wayOfMoving}";
        }

        public virtual void DoSomething()
        {
            Console.WriteLine($"This {this.GetType().Name} do something !");
        }
    }
}
