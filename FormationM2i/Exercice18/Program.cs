using System;

namespace Exercice18
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
                switch (childrenAge)
                {
                    case var expression when childrenAge > 17:
                        Console.WriteLine("L'enfant est un adulte !");
                        break;
                    case var expression when childrenAge > 12:
                        Console.WriteLine("La catégorie est Cadet !");
                        break;
                    case var expression when childrenAge > 10:
                        Console.WriteLine("La catégorie est Minime !");
                        break;
                    case var expression when childrenAge > 8:
                        Console.WriteLine("La catégorie est Pupile !");
                        break;
                    case var expression when childrenAge > 6:
                        Console.WriteLine("La catégorie est Poussin !");
                        break;
                    case var expression when childrenAge > 2:
                        Console.WriteLine("La catégorie est Baby !");
                        break;
                    default:
                        Console.WriteLine("L'enfant est trop jeune !");
                        break;
                }
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
