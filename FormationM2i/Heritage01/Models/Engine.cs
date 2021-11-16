using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage01.Models
{
    internal class Engine
    {
        private double actualVolume;
        private double maxVolume;
        private bool isOn;
        public double ActualVolume { get => actualVolume; set => actualVolume = value; }
        public double MaxVolume { get => maxVolume; set => maxVolume = value; }
        public bool IsOn { get => isOn; set => isOn = value; }

        public Engine(double maxVolume)
        {
            this.maxVolume = maxVolume;
        }

        public bool Start()
        {
            if (actualVolume > 0.1 && !isOn)
            {
                actualVolume -= 0.1;
                isOn = true;
                Console.WriteLine("Engine started.");
                return true;
            }

            return false;
        }

        public double Use(double amount)
        {
            if (!IsOn)
            {
                Start();
            }

            if (actualVolume > amount)
            {
                actualVolume -= amount;
                Console.WriteLine($"Engine used {amount} liter{(amount > 1 ? "s" : null)}.");
            }

            return maxVolume - actualVolume;
        }

        public void Fill(double amount)
        {
            if (amount > 0 && actualVolume + amount <= maxVolume)
            {
                actualVolume += amount;
                Console.WriteLine($"Engine filled with {amount} liter{(amount > 1 ? "s" : null)}.");
            }
            else if (amount > 0) 
            {
                actualVolume = maxVolume;
                Console.WriteLine($"Engine filled entirely !");
            }

        }

        public bool Stop()
        {
            if (isOn)
            {
                isOn = false;
                Console.WriteLine("Engine stoped.");
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{Math.Round(actualVolume, 2)}/{maxVolume} => {(isOn ? "ON" : "OFF")}";
        }
    }
}
