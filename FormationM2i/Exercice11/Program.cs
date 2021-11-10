using System;

namespace Exercice11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Le nombre est-il divisible par... ? ---");

            try
            {
                Console.Write("Entrez un premier nombre : ");
                int nbA = Convert.ToInt32(Console.ReadLine());
                Console.Write("Entrez un second nombre : ");
                int nbB = Convert.ToInt32(Console.ReadLine());

                if (nbA % nbB == 0)
                {
                    if (nbA.ToString().Length > 1) Console.WriteLine($"Le nombre {nbA} est bien divisible par {nbB} !");
                    else Console.WriteLine($"Le chiffre {nbA} est bien divisible par {nbB} !");
                }
                else Console.WriteLine($"Le nombre {nbA} n'est pas divisible par {nbB}.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERR: Problème de format de conversion !");
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
