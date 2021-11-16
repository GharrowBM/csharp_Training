using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage01.Models
{
    internal class Car : VehiculeWithEngine
    {
        public Car(string brand, string model, double engineSize) : base(brand, model, engineSize)
        {
        }

        public void Move(double amount)
        {
            engine.Use(amount);
        } 
    }
}
