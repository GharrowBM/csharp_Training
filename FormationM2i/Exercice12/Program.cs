using System;

namespace Exercice12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Dans quelle catégorie mon enfant est-il...? ---");

            try
            {
                Console.Write("Entrez l'âge de votre enfant : ");
                int childrenAge = Convert.ToInt32(Console.ReadLine());
                if (childrenAge > 17) Console.WriteLine("L'enfant est un adulte !");
                else if (childrenAge >12) Console.WriteLine("La catégorie est Cadet !");
                else if (childrenAge >10) Console.WriteLine("La catégorie est Minime !");
                else if (childrenAge >8) Console.WriteLine("La catégorie est Pupile !");
                else if (childrenAge >6) Console.WriteLine("La catégorie est Poussin !");
                else if (childrenAge > 2) Console.WriteLine("La catégorie est Baby !");
                else Console.WriteLine("L'enfant est trop jeune !");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERR: Problème de conversion de la saisie utilisateur.");
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
