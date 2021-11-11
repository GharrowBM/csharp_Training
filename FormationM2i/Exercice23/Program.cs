using System;

namespace Exercice23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int population = 96809, years = 1;
            double growthRate = 0.89 / 100;

            Console.WriteLine("--- Accroissement de population ---");
            Console.WriteLine($"La ville de Tourcoing compte {population} habitants en 2015.");
            for (years = 1; population < 120000; years++)
            {
                population = Convert.ToInt32(Math.Truncate(population + population * growthRate));
            }

            years--;

            Console.WriteLine($"Il faudra {years} ans, nous serons en {years + 2015}");
            Console.WriteLine($"Il y aura {population} habitants en {years + 2015}");
        }
    }
}
