using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage01.Models
{
    abstract class Vehicule
    {
        protected string brand;
        protected string model;

        public Vehicule(string brand, string model)
        {
            this.brand = brand;
            this.model = model;
        }

        public abstract bool Start();
        public abstract bool Stop();
        public abstract void Fill(double liter);

    }
}
