using System;

namespace Exercice08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Entrez le prix HT de l'objet (en Euros) : ");
                double itemPrice = Convert.ToDouble(Console.ReadLine());
                Console.Write("Entrez le taux de TVA (en %) : ");
                int percent = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Le montant de la T.V.A. est de {Math.Round((itemPrice * percent) / 100, 2)} euros.");
                Console.WriteLine($"Le prix TTC de l'objet est de {Math.Round(itemPrice + (itemPrice * percent) / 100, 2)} euros.");

            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
