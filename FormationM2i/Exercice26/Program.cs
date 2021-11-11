using System;

namespace Exercice26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int population = 96809, years = 1;
            double growthRate = 0.89 / 100;

            Console.WriteLine("--- Accroissement de population ---");
            Console.WriteLine($"La ville de Tourcoing compte {population} habitants en 2015.");

            while (population < 120000)
            {
                population += Convert.ToInt32(Math.Truncate(population * growthRate));
                years++;
            }

            years--;

            Console.WriteLine($"Il faudra {years} ans, nous serons en {years + 2015}");
            Console.WriteLine($"Il y aura {population} habitants en {years + 2015}");
        }
    }
}
