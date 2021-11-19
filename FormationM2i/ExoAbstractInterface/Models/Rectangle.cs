using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoAbstractInterface.Models
{
    internal class Rectangle : Figure, IDeformable
    {
        private double length;
        private double heigth;

        public Rectangle(double posX, double posY, double length, double height) : base (posX, posY)
        {
            this.length = length;
            this.heigth = height;
        }

        public Figure Deform(double coefH, double coefV)
        {
            if (length * coefH == heigth * coefV)
            {
                return new Square(posX, posY, length * coefH);
            }
            else
            {
                return new Rectangle(posX, posY, length*coefH, length * coefV);
            }
        }

        public override void Print()
        {
            Console.WriteLine($"Rectangle : A({posX};{posY}) B({posX + length};{posY}) C({posX};{posY + heigth}) D({posX + length};{posY + heigth})");
        }
    }
}
