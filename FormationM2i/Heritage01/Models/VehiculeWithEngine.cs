using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage01.Models
{
    abstract class VehiculeWithEngine : Vehicule
    {
        protected Engine engine;

        public VehiculeWithEngine(string brand, string model, double engineSize) : base(brand, model)
        {
            this.engine = new Engine(engineSize);
        }

        public override bool Start()
        {
            return engine.Start();
        }

        public override bool Stop()
        {
            return engine.Stop();
        }

        public override void Fill(double liter)
        {
            if (!engine.IsOn)
            {
                engine.Fill(liter);
                engine.Start();
            }
        }

        public override string ToString()
        {
            return $"{brand} {model} - Engine : {engine}";
        }


    }
}
