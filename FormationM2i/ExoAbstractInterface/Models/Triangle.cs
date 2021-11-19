using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoAbstractInterface.Models
{
    internal class Triangle : Figure
    {
        private double baseLength;
        private double height;

        public Triangle (double posX, double posY, double baseLength, double height) : base(posX, posY)
        {
            this.baseLength = baseLength;
            this.height = height;
        }

        public override void Print()
        {
            Console.WriteLine($"Triangle : A({posX};{posY}) B({posX+baseLength};{posY}) C({posX+baseLength/2};{posY+height})");
        }
    }
}
