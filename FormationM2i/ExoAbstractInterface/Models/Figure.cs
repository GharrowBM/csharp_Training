using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoAbstractInterface.Models
{
    internal abstract class Figure
    {
        protected double posX;
        protected double posY;

        public Figure(double posX, double posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        public abstract void Print();
    }
}
