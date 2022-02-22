using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01.Classes
{
    internal class Dog : Mammal 
    {
        public override string Move(string wayOfMoving = "Walking")
        {
            return $"This {this.GetType().Name} moves with : {wayOfMoving}";
        }

        public override void DoSomething()
        {
            base.DoSomething();
            Console.WriteLine($"{this.GetType().Name} chases his tail !");
        }

        public void Bark()
        {
            Console.WriteLine($"This {this.GetType().Name} says : WOOF ! WOOF !");
        }
    }
}
