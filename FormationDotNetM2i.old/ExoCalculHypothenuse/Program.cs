using System;

namespace ExoCalculHypothenuse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Calcul de la longueur de l'hypothénuse ---");
            try
            {
                Console.Write("Entrez la longueur d'un côté du rectangle (en cm) : ");
                double rectangleLength = Convert.ToDouble(Console.ReadLine());
                Console.Write("Entrez la longueur d'un autre côté du rectangle (en cm) : ");
                double rectangleHeight = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"L'hypothénuse du rectangle est {Math.Round(Math.Sqrt(Math.Pow(rectangleHeight, 2) + Math.Pow(rectangleLength,2)), 2)} cm");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERR: La valeur entrée n'est pas un nombre correct...");
                ex.ToString();
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
