using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicePOO01
{
    internal class Chair
    {
        private int NbFeet;
        private string color;
        private string material;

        public Chair() {
            this.NbFeet = 4;
            this.color = "white";
            this.material = "wood";
        }

        public Chair(int nbFeet, string color, string material)
        {
            this.NbFeet = nbFeet;
            this.color = color;
            this.material = material;
        }

        public override string ToString()
        {
            return NbFeet > 1 ? $"This chair has {this.NbFeet} feet, is made of {this.material} and has a {this.color} color..." 
                                : $"This chair has {this.NbFeet} foot, is made of {this.material} and has a {this.color} color...";
        }

    }
}
