using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01.Classes
{
    internal class Cat : Mammal
    {
        public override string Move(string wayOfMoving = "Jumping")
        {
            return $"This {this.GetType().Name} moves with : {wayOfMoving}";
        }

        public override void DoSomething()
        {
            base.DoSomething();
            Console.WriteLine($"{this.GetType().Name} breaks some stuff !");
        }

        public void Meow()
        {
            Console.WriteLine($"This {this.GetType().Name} says : Shut up and let me sleep, human !");
        }
    }
}
