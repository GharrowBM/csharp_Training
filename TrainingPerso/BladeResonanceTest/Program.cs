using System;
using System.Linq;

namespace BladeResonanceTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
             * Base formula for calculation from https://xenoblade.fandom.com/wiki/Blade_Resonance
             * Probability = max((sqrt(Luck stat) * 0.013) + 0.95, 1) * 0.01 * (100 + 5 * [Idea Multiplier]) * [Core Rarity] * [Blade Base Probability] 
             */

            Console.Write("Donnez la valeur de votre CHANCE : ");
            if (double.TryParse(Console.ReadLine(), out double luck))
            {
                Console.Write("Donnez la valeur de votre VERTUS : ");
                if (double.TryParse(Console.ReadLine(), out double ideaMultiplier))
                {
                    Console.Write("Choississez votre coeur : "
                          + "\n\t1--Commun"
                          + "\n\t2--Rare"
                          + "\n\t3--Légendaire"
                          + "\nQuel type de coeur ? ");
                    if (int.TryParse(Console.ReadLine(), out int coreRarityChoice))
                    {
                        double coreRarity = coreRarityChoice == 1 ? 1.0 : coreRarityChoice == 2 ? 1.5 : coreRarityChoice == 3 ? 3.0 : 0.0;

                        Console.Write("Donnez la probabilité de base de la lame : ");

                        if (double.TryParse(Console.ReadLine(), out double bladeBaseProbability))
                        {
                            double probability = Math.Round((Math.Max(Math.Sqrt(luck) * 0.013 + 0.95, 1) * 0.01 * (100 + 5 * ideaMultiplier) * coreRarity * bladeBaseProbability), 2);

                            Console.WriteLine($"Votre probabilité d'avoir cette lame en l'état actuel est de {probability}%");

                        }


                    }
                }
            }
        }
    }
}
