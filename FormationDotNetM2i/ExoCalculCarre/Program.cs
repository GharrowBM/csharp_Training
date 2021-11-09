using System;

namespace ExoCalculCarre
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Calcul du périmètre et de l'aire d'un carré ---");
            try
            {
                Console.Write("Entrez la longueur d'un côté du carré (en cm) : ");
                double squareLength = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"Le périmètre du carré est {Math.Round(squareLength * 4)} cm");
                Console.WriteLine($"L'aire du carré est {Math.Round(Math.Pow(squareLength, 2), 2)} cm²");
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


            Console.WriteLine("--- Calcul du périmètre et de l'aire d'un rectangle ---");
            try
            {
                Console.Write("Entrez la longueur du rectangle (en cm) : ");
                double rectangleLength = Convert.ToDouble(Console.ReadLine());
                Console.Write("Entrez la largeur du rectangle (en cm) : ");
                double rectangleHeight= Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"Le périmètre du rectangle est {Math.Round(rectangleLength * 2 + rectangleHeight *2)} cm");
                Console.WriteLine($"L'aire du rectangle est {Math.Round(rectangleLength * rectangleHeight, 2)} cm²");
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
