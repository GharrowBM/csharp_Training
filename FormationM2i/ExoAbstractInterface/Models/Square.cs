using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoAbstractInterface.Models
{
    internal class Square : Figure, IDeformable
    {
        private double length;

        public Square(double posX, double posY, double length) : base(posX, posY)
        {
            this.length = length;
        }

        public Figure Deform(double coefH, double coefV)
        {
            if (coefH != coefV)
            {
                return new Rectangle(posX, posY, length * coefH, length * coefV);
            }
            else
            {
                return new Square(posX, posY, length * coefH);
            }
        }

        public override void Print()
        {
            Console.WriteLine($"Square : A({posX};{posY}) B({posX + length};{posY}) C({posX};{posY + length}) D({posX+length};{posY+length})");
        }
    }
}
