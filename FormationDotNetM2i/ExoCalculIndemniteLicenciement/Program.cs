using System;
using System.Globalization;

namespace ExoCalculIndemniteLicenciement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- Quelle sera le montant de l'indémnité de licenciement ? ---");

            try
            {
                Console.Write("Merci de saisir le dernier salaire (en euros) : ");
                double lastSalary = Convert.ToDouble(Console.ReadLine());
                Console.Write("Merci de saisir votre âge : ");
                double age = Convert.ToDouble(Console.ReadLine());
                Console.Write("Merci de saisir le nombre d'années d'ancienneté : ");
                double years = Convert.ToDouble(Console.ReadLine());
                double result = 0.0;

                if (years  > 10)
                {
                    result = lastSalary * years;
                } else if (years > 0)
                {
                    result = lastSalary / 2 * years;
                }

                if (age > 50)
                {
                    result += lastSalary * 5;
                } else if (age > 45)
                {
                    result += lastSalary * 2;
                }
                

                Console.WriteLine($"Votre indémnité est de : {(result).ToString("C", CultureInfo.CurrentCulture)}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERR: Erreur lors de la conversion de la saisie utilisateur.");
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
