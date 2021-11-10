using System;
using System.Globalization;

namespace ExoCalculInterets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Calcul des Intérêts ---");
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            try
            {
                Console.Write("Entrez le capital de départ (en euros) : ");
                double baseCapital = Convert.ToDouble(Console.ReadLine());
                Console.Write("Entrez le taux d'intérêts (en %) : ");
                double percent = Convert.ToDouble(Console.ReadLine());
                Console.Write("Entrez la durée de l'épargne (en années) : ");
                double years = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine($"Le montant des intérêts sera de {Math.Round(baseCapital * Math.Pow(1 + percent / 100, years) - baseCapital, 2).ToString("C", CultureInfo.CurrentCulture)} après {years} ans.");
                Console.WriteLine($"Le capital final sera de {Math.Round(baseCapital * Math.Pow(1 + percent / 100, years), 2).ToString("C", CultureInfo.CurrentCulture)} ");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERR: La valeur entrée n'est pas un nombre...");
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
